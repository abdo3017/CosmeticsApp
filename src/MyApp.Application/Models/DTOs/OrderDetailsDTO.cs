using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductQty { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int? AttrValueId { get; set; }
        public string? attributeName { get; set; }
        public string? productName { get; set; }
        public byte[]? ProductImage { get; set; }
    }
}
