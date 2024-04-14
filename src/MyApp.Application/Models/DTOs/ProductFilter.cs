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
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Discount { get; set; }
        public bool Best { get; set; }
        public bool Recent { get; set; }
        public bool MostPopular { get; set; }
        public List<int>? Tags { get; set; }
    }
}
