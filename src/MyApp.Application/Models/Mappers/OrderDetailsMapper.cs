using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class OrderDetailsMapper
    {

        public static OrderDetail Map(this OrderDetailsDTO dto, int OrderId, decimal ProductPrice)
        {
            return new OrderDetail
            {
                OrderId = OrderId,
                ProductId = dto.ProductId,
                Qty = dto.ProductQty,
                TotalPrice = dto.ProductQty * ProductPrice,
                AttrValueId = dto.AttrValueId
            };
        }

        public static OrderDetailsDTO Map(this OrderDetail dto)
        {
            return new OrderDetailsDTO
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                ProductQty = dto.Product.Qty,
                TotalPrice = dto.Product.Qty * dto.Product.Price,
                AttrValueId = dto.AttrValueId
            };
        }
    }
}
