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
    public static class BrandMapper
    {
        public static Brand Map(this BrandDTO dto)
        {
            return new Brand
            {
                Name = dto.Name,
                Image = dto.Image,
                Id = dto.Id,
                NameAr = dto.NameAr,
            };
        }

        public static BrandDTO Map(this Brand brand)
        {
            return new BrandDTO
            {
                Name = CultureInfo.CurrentCulture.Name=="en"?brand.Name:brand.NameAr,
                Id = brand.Id,
                Image = brand.Image,
                NameAr= brand.NameAr,
            };
        }

        public static SearchResult MapTOSearchResult(this Brand dto)
        {
            return new SearchResult
            {

                Name = dto.Name,
                Key = dto.Id,
                Type = SearchResultType.Brand
            };
        }
    }
}
