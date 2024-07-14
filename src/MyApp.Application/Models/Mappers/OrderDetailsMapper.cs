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
                ProductQty = dto.Qty,
                ProductPrice = dto.Product.Price,
                TotalPrice = dto.TotalPrice,
                AttrValueId = dto.AttrValueId,
                productName = dto.Product.Name,
                attributeName = dto.Product?.AttributeValues.FirstOrDefault(a => a.Id == dto.AttrValueId)?.Value,
                ProductImage = dto.Product?.Imgs?.FirstOrDefault(g => g.IsCover)?.Image
            };



        }
    }
}
