using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class OrderDetailsDTO
    {
        public int ProductId { get; set; }
        public int ProductQty { get; set; }
        public int AttrValueId { get; set; }
    }
}
