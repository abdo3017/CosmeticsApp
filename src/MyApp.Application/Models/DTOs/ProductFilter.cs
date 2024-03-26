using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class ProductFilter
    {
        public List<int>? CategoryIds { get; set; }
        public List<int>? BrandIds { get; set; }
        public List<Decimal>? PriceRange { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? UptoDiscount { get; set; }
        public List<string>? Tags { get; set; }
    }
}
