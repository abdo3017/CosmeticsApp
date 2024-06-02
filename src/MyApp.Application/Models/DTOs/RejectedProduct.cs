using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class RejectedProduct
    {
        public int ProductId { get; set; }
        public int? AttrValueId { get; set; }
        public string AttrName { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }

    }
}
