using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; } = 0;
        public int ProductId { get; set; }
        public int OrderId { get; set; } = 0;
        public int ProductQty { get; set; }
        public decimal ProductPrice { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;
        public int? AttrValueId { get; set; } = 0;
    }
}
