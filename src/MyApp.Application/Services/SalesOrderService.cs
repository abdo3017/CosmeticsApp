using Microsoft.EntityFrameworkCore;
using MyApp.Application.Core.Services;
using MyApp.Application.Core.Specifications;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class SalesOrderService : BaseOrderService, ISalesOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IOrderDetailsService _OrderDetailsService;
        private readonly IShipmentCostService _shipmentCostService;
        private readonly IAttributeValueService _attributeValueService;

        public SalesOrderService(IUnitOfWork unitOfWork, IProductService productService, IAttributeValueService attributeValueService, IOrderDetailsService orderDetailsService, IShipmentCostService shipmentCostService)
            : base(unitOfWork, productService, attributeValueService, orderDetailsService, shipmentCostService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _OrderDetailsService = orderDetailsService;
            _shipmentCostService = shipmentCostService;
            _attributeValueService = attributeValueService;

        }

        public async Task CancelOrder(int id)
        {
            var order = await GetOrderWithDetailsById(id);

            order?.Items.ForEach(async item => await UpdateReturnedQty(item));

            order.Status = (byte)OrderStatus.Canceled;

            Update(order);

        }

        public async Task<List<OrderDTO>> GetOrdersByCustomerId(int customerId)
        {
            var spec = new BaseSpecification<Order>(x => x.Type == (int)OrderType.Sales && x.CustomerId == customerId);
            spec.ApplyOrderByDescending(x => x.CreatedAt);
            return await GetOrdersByCustomerId(spec);
        }

        public async Task<PlaceOrderResultDTO> PlaceOrderAsync(OrderDTO DTO)
        {

            var ReserveResult = await ReserveQtyAsync(DTO.Items); //reserv Qty 
            if (ReserveResult.IsValidOrder)
            {
                var Order = await Create(DTO); // create order 

                //var orderDetails = from orderDetail in DTO.Items
                //                   join rejectedProducts in ReserveResult.RejectedProductIds
                //                   on
                //                   new { orderDetail.ProductId, orderDetail.AttrValueId }
                //                   equals
                //                   new { rejectedProducts.ProductId, rejectedProducts.AttrValueId }
                //                   where rejectedProducts.ProductId ==null && rejectedProducts.AttrValueId == null
                //                   select orderDetail;
                var orderDetails = DTO.Items.Where(i => !ReserveResult.RejectedProductIds.Any(r => r.ProductId == i.ProductId && r.AttrValueId == i.AttrValueId));

                foreach (var orderDetail in orderDetails) //create details
                {
                    var Product = await _productService.GetProductById(orderDetail.ProductId);
                    decimal ProductPriceAfterDiscount = Product.Price - (Product.DiscountPercentage * Product.Price / 100);
                    var CreatedOrderDetail = await _OrderDetailsService.Create(orderDetail, Order.Id, ProductPriceAfterDiscount);
                    Order.TotalPrice += CreatedOrderDetail.TotalPrice;
                }
                if (DTO.DeliveryType == (byte)DeliveryType.Home)
                {
                    var cost = await _shipmentCostService.GetShipmentCostByAddressId(DTO.AddressId);
                    if (cost != null)
                    {
                        Order.TotalPrice += cost.Cost;
                    }
                }
                Update(Order); // update order total 
                ReserveResult.OrderID = Order.Id;
                ReserveResult.TotalPrice = Order.TotalPrice;
            }
            return ReserveResult;
        }

        public async Task<PlaceOrderResultDTO> ReserveQtyAsync(List<OrderDetailsDTO> DTOs)
        {
            var Res = new PlaceOrderResultDTO();
            foreach (var orderDetail in DTOs)
            {
                try
                {
                    await CheckAndCutQtyAsync(Res, orderDetail);
                }
                catch (DbUpdateConcurrencyException ex)  // in case of  Concurrency keep rebate the process 
                {
                    await CheckAndCutQtyAsync(Res, orderDetail);
                }
            }
            Res.IsValidOrder = DTOs.Count() > Res.RejectedProductIds.Count(); // chaeck if all items rejected then the order isn't valiad and no order will be created 
            return Res;
        }


        async Task CheckAndCutQtyAsync(PlaceOrderResultDTO Res, OrderDetailsDTO orderDetail)
        {
            //await BeginTransactionAsync(IsolationLevel.RepeatableRead);

            //check qty for prod
            bool isValid = true;
            if (orderDetail.AttrValueId != null)
            {

                var attrValue = await _attributeValueService.GetAttributeValuesByIdAsNoTracking((int)orderDetail.AttrValueId);
                if (attrValue is AttributeValueDTO)
                {
                    if (attrValue.Qty >= orderDetail.ProductQty)
                    {
                        isValid = true;
                        attrValue.Qty -= orderDetail.ProductQty;
                        _attributeValueService.UpdateAttrValWithoutValidatingAndSaving(attrValue.MapForUpdate());
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            //check qty for attr 

            if (isValid)
            {
                var productDto = await _productService.GetProductByIdAsNoTracking(orderDetail.ProductId);
                if (productDto is productDTO && productDto.Qty >= orderDetail.ProductQty)
                {
                    productDto.Qty -= orderDetail.ProductQty;
                    _productService.UpdateProductWithoutSave(productDto);
                    UnitOfWork.SaveChanges();
                    //await CommitAskdync();
                }
            }
            if (!isValid)
            {
                try
                {
                    var product = await _productService.GetProductById(orderDetail.ProductId);
                    AttributeValueDTO atrr = null;
                    if (orderDetail.AttrValueId != null)
                    {
                        atrr = await _attributeValueService.GetAttributeValuesById((int)orderDetail.AttrValueId);
                    }
                    Res.RejectedProductIds.Add(new RejectedProduct
                    {
                        ProductId = orderDetail.ProductId,
                        AttrValueId = orderDetail.AttrValueId,
                        ProductName = product?.Name,
                        Qty = atrr is null ? product.Qty : atrr.Qty,
                        AttrName = atrr?.AttributeName
                    });
                }
                catch { throw; }
                finally
                {
                    //await RollbackAsync();
                }

            }

        }

    }
}



// check qty product
//cut qty 
//create order 
//create orderDetails
//