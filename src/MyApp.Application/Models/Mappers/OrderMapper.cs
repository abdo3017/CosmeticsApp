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

        

        public static Order Map(this OrderDTO dto)
        {
            return new Order
            {
                Id = dto.Id,
                AddressId = dto.AddressId,
                CustomerId = dto.CustomerId,
                CreatedAt = DateTime.Now,
                Status = dto.Status,
                DeliveryType = dto.DeliveryType,
                Type = dto.Type,
                OrderDetails = dto.Items.Select(s => s.Map(dto.Id,s.ProductPrice)).ToList()
            };
        }

        public static OrderDTO Map(this Order dto)
        {
            return new OrderDTO
            {
                Id = dto.Id,
                AddressId = dto.AddressId,
                CustomerId = dto.CustomerId,
                Status = dto.Status,
                DeliveryType = (byte)dto.DeliveryType,
                Type = dto.Type,
                TotalPrice = dto.TotalPrice,
                Items = dto.OrderDetails.Select(s => s.Map()).ToList()
            };
        }
    }
}
