using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                Tag = dto.Tag,
                
            };
        }

        public static Product Map(this CreateProductDTO dto)
        {
            return new Product
            {
              
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                BrandId = dto.BrandId,
                Price = dto.Price,
                Qty = dto.Qty,
                DiscountPercentage = dto.DiscountPercentage,             
                Tag = dto.Tag,
                NameAr = dto.NameAr
            };
        }

        public static productDTO Map(this Product pro)
        {
            return new productDTO
            {
                Id = pro.Id,
                Name = CultureInfo.CurrentCulture.Name == "en" ? pro.Name :pro.NameAr,
                CategoryId = pro.CategoryId,
                Description = pro.Description,
                BrandId = pro.BrandId,
                Price = pro.Price,
                Qty = pro.Qty,
                CreationDate = pro.CreationDate,
                DiscountPercentage = pro.DiscountPercentage,
                Tag = pro.Tag,
                TotalRate = pro.TotalRate,
                RateValue = pro.RateValue,
                CoverImg = pro.Imgs.SingleOrDefault(i => i.IsCover)?.Image,
                CategoryName = pro.Category?.Name,
                BrandName = pro.Brand?.Name,
                HasAttr = pro.AttributeValues.Count() > 0,
                NameAr = pro.NameAr
                

            };
        }


        public static ProductDetailsDTO MapToProDetails(this Product pro)
        {
            return new ProductDetailsDTO
            {
                Id = pro.Id,
                Name = CultureInfo.CurrentCulture.Name == "en" ? pro.Name : pro.NameAr,
                Tag = pro.Tag,
                Description = pro.Description,
                BrandImg = pro.Brand?.Image,
                Price = pro.Price,
                RateValue = pro.RateValue,
                TotalRate = pro.TotalRate,
                CreationDate = pro.CreationDate,
                Qty = pro.Qty,
                DiscountPercentage = pro.DiscountPercentage,
                AttributeValues = pro.AttributeValues.Select(s=>s.Map()).GroupBy(p=> p.AttributeId),
                ProductImgs = pro.Imgs,
                BrandName = pro.Brand?.Name
            };
        }


        public static SearchResult MapTOSearchResult(this Product dto)
        {
            return new SearchResult
            {

               Name = dto.Name,
               Key = dto.Id,
               Type= SearchResultType.Product
            };
        }
    }
}
