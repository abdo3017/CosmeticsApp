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
    public class OrderService : BaseService<Order, int>, IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IOrderDetailsService _OrderDetailsService;
        //public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        public OrderService(IUnitOfWork unitOfWork, IProductService productService, IOrderDetailsService orderDetailsService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _OrderDetailsService = orderDetailsService;
        }

        public async Task<Order> Create(OrderDTO DTO)
        {
            var SalesOrder = await AddAsync(DTO.MapSalesOrderCreation());
            return SalesOrder;
        }

        public async Task<PlaceOrderResultDTO> PlaceOrderAsync(OrderDTO DTO)
        {

            var ReserveResult = await ReserveQtyAsync(DTO.Items); //reserv Qty 
            if (ReserveResult.IsValidOrder)
            {
                var Order = await Create(DTO); // create order 

                var exc = DTO.Items.Where(i => !ReserveResult.RejectedProductIds.Any(r => r.ProductId == i.ProductId && r.AttrValueId == i.AttrValueId));
                foreach (var orderDetail in exc) //create details
                {
                    var Product = await _productService.GetProductById(orderDetail.ProductId);
                    var CreatedOrderDetail = await _OrderDetailsService.Create(orderDetail, Order.Id, Product.Price);
                    Order.TotalPrice += CreatedOrderDetail.TotalPrice;
                }
                Update(Order); // update order total 
                ReserveResult.OrderID = Order.Id;
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
                    await CheckAndCutProductQtyAsync(Res, orderDetail);
                }
                catch (DbUpdateConcurrencyException ex)  // in case of  Concurrency keep rebate the process 
                {
                    await CheckAndCutProductQtyAsync(Res, orderDetail);
                }
            }
            Res.IsValidOrder = DTOs.Count() > Res.RejectedProductIds.Count(); // chaeck if all items rejected then the order isn't valiad and no order will be created 
            return Res;
        }


        async Task CheckAndCutProductQtyAsync(PlaceOrderResultDTO Res, OrderDetailsDTO orderDetail)
        {
            if (!await _productService.IsAvailableProduct(orderDetail))
                Res.RejectedProductIds.Add(new RejectedProduct
                {
                    ProductId = orderDetail.ProductId,
                    AttrValueId = orderDetail.AttrValueId
                });
        }

    }
}



// check qty 
//cut qty 
//create order 
//create orderDetails
//