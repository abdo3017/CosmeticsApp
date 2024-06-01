using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = null!;
        public string? NameAr { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public int BrandId { get; set; } = -1;
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int DiscountPercentage { get; set; }
        public int? Tag { get; set; }
    }
}
