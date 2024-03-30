using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
   public class AdvertisementFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? Discount { get; set; }
        public string? Tag { get; set; }
    }
}
