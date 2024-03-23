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
        public List<string>? Tags { get; set; }
    }
}
