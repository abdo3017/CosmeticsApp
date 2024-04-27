using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class OrderMapper
    {

      public  static OrderDetail Map( this  OrderDetailsDTO dto , int OrderId, decimal ProductPrice)
        {
            return new OrderDetail
            {
                OrderId = OrderId,
                ProductId = dto.ProductId,
                Qty = dto.ProductQty, 
                TotalPrice = dto.ProductQty* ProductPrice, 
                AttrValueId = dto.AttrValueId
            };
        }

      public  static Order MapSalesOrderCreation ( this OrderDTO dto )
        {
            return new Order
            {
                AddressId = dto.AddressId,
                CustomerId = dto.CustomerId,
                CreatedAt = DateTime.Now,
                Status = 0,
                Type = 0,
                
                
            };
        }
    }
}
