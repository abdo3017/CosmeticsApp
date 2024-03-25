using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } 
        public string TagName { get; set; } 

        public string? Description { get; set; }

        public byte[]? BrandImg { get; set; }

        public decimal Price { get; set; }

        public decimal RateValue { get; set; }

        public int TotalRate { get; set; }

        public int DiscountPercentage { get; set; }

        public ICollection<Gallery>? ProductImgs { get; set; }

        public  ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    }
}
