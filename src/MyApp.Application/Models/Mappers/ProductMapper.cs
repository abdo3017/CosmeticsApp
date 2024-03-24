using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class ProductMapper
    {

        public static Product Map (this productDTO dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Description= dto.Description,
                BrandId = dto.BrandId,
                Price = dto.Price,
                Qty = dto.Qty,
                DiscountPercentage = dto.DiscountPercentage,
                TotalRate = dto.TotalRate,
                RateValue = dto.RateValue,
                TagName = dto.TagName,
                
            };
        }

        public static productDTO Map(this Product pro)
        {
            return new productDTO
            {
                Id = pro.Id,
                Name = pro.Name,
                CategoryId = pro.CategoryId,
                Description = pro.Description,
                BrandId = pro.BrandId,
                Price = pro.Price,
                Qty = pro.Qty,
                DiscountPercentage = pro.DiscountPercentage,
                TagName = pro.TagName,
                TotalRate = pro.TotalRate,
                RateValue = pro.RateValue,
                CoverImg = pro.Imgs.SingleOrDefault(i => i.IsCover)?.Image,
                CategoryName = pro.Category.Name
                
            };
        }

        public static ProductDetailsDTO MapToProDetails(this Product pro)
        {
            return new ProductDetailsDTO
            {
                Id = pro.Id,
                Name = pro.Name,
                TagName = pro.TagName,
                Description = pro.Description,
                BrandImg = pro.Brand?.Image, // will be change
                Price = pro.Price,
                RateValue = pro.RateValue,
                TotalRate = pro.TotalRate,
                DiscountPercentage = pro.DiscountPercentage,
                AttributeValues = pro.AttributeValues,
                ProductImgs = pro.Imgs,
            };
        }
    }
}
