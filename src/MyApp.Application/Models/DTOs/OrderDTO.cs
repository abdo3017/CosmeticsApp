using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; } = 0;
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public byte DeliveryType { get; set; }
        public byte Type { get; set; } = (byte)OrderType.Sales;
        public byte Status { get; set; } = (byte)OrderStatus.Open;

        public List<OrderDetailsDTO> Items { get; set; }

    }
}
