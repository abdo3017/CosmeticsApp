using MyApp.Domain.Entities;

namespace MyApp.Application.Models.DTOs
{
    public class productDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameAr { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }

        public int Qty { get; set; }
        public int DiscountPercentage { get; set; }
        public int Tag { get; set; } = -1;
        public byte[]? CoverImg { get; set; }
        public decimal RateValue { get; set; }
        public int TotalRate { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }

        public bool HasAttr { get; set; } = false; 
    }
}