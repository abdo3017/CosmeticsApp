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
        private readonly IShipmentCostService _shipmentCostService;

        public ReturnOrderService(IUnitOfWork unitOfWork, IProductService productService, IAttributeValueService attributeValueService, IOrderDetailsService orderDetailsService, IShipmentCostService shipmentCostService)
            : base(unitOfWork, productService, attributeValueService, orderDetailsService, shipmentCostService)
        {
            _productService = productService;
            _attributeValueService = attributeValueService;
            _OrderDetailsService = orderDetailsService;
            _shipmentCostService = shipmentCostService;
        }

        public async Task<PlaceOrderResultDTO> PlaceOrderAsync(OrderDTO DTO)
        {
            DTO.Items.ForEach(async item =>
            {
                await UpdateReturnedQty(item);
            });
            var order = await Create(DTO); // create order 
            var placeOrderResultDTO = new PlaceOrderResultDTO();

            placeOrderResultDTO.IsValidOrder = true;
            placeOrderResultDTO.OrderID = order.Id;
            foreach (var orderDetail in DTO.Items) //create details
            {
                var Product = await _productService.GetProductById(orderDetail.ProductId);
                if (Product != null)
                {
                    var CreatedOrderDetail = await _OrderDetailsService.Create(orderDetail, order.Id, Product.Price);
                    order.TotalPrice += CreatedOrderDetail.TotalPrice;
                }
            }
            var cost = await _shipmentCostService.GetShipmentCostByAddressId(DTO.AddressId);
            if (cost != null)
            {
                order.TotalPrice += cost.Cost;
            }
            ConfirmOrder(order.Map());
            //Update(order); // update order total 
            return placeOrderResultDTO;
        }




    }
}
