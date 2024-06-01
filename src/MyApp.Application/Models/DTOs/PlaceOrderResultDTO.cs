using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class PlaceOrderResultDTO
    {
        public bool IsValidOrder { get; set; }
        public int? OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public List<RejectedProduct> RejectedProductIds { get; set;  } = new List<RejectedProduct>();
    }
}
