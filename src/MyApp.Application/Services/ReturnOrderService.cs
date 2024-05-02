using Microsoft.EntityFrameworkCore;
using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class ReturnOrderService : BaseOrderService, IReturnOrderService
    {

        private readonly IProductService _productService;
        private readonly IAttributeValueService _attributeValueService;
        private readonly IOrderDetailsService _OrderDetailsService;

        public ReturnOrderService(IUnitOfWork unitOfWork, IProductService productService, IAttributeValueService attributeValueService, IOrderDetailsService orderDetailsService) : base(unitOfWork)
        {
            _productService = productService;
            _attributeValueService = attributeValueService;
            _OrderDetailsService = orderDetailsService;
        }

        public async Task<PlaceOrderResultDTO> PlaceOrderAsync(OrderDTO DTO)
        {
            DTO.Items.ForEach(async item =>
            {
                await UpdateReturnedQty(item);
            });
            var Order = await Create(DTO); // create order 
            var placeOrderResultDTO = new PlaceOrderResultDTO();

            placeOrderResultDTO.IsValidOrder = true;
            placeOrderResultDTO.OrderID = Order.Id;
            foreach (var orderDetail in DTO.Items) //create details
            {
                var Product = await _productService.GetProductById(orderDetail.ProductId);
                if (Product != null)
                {
                    var CreatedOrderDetail = await _OrderDetailsService.Create(orderDetail, Order.Id, Product.Price);
                    Order.TotalPrice += CreatedOrderDetail.TotalPrice;
                }
            }

            Update(Order); // update order total 
            return placeOrderResultDTO;
        }


        async Task UpdateReturnedQty(OrderDetailsDTO orderDetail)
        {
            await UpdateProductWithReturnedQty(orderDetail);
            await UpdateAttributeValueWithReturnedQty(orderDetail);
        }

        async Task UpdateProductWithReturnedQty(OrderDetailsDTO orderDetail)
        {
            var product = await _productService.GetProductById(orderDetail.ProductId);
            if (product is productDTO)
            {
                product.Qty += orderDetail.ProductQty;
                _productService.UpdateProduct(product);
            }
        }

        async Task UpdateAttributeValueWithReturnedQty(OrderDetailsDTO orderDetail)
        {
            var attributeValue = await _attributeValueService.GetAttributeValuesById(orderDetail.AttrValueId);
            if (attributeValue is AttributeValueDTO)
            {
                attributeValue.Qty += orderDetail.ProductQty;
                await _attributeValueService.UpdateAttrVal(attributeValue.MapForUpdate());
            }
        }

    }
}
