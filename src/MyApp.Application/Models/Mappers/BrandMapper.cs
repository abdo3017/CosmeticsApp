using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
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
                Id = dto.Id
            };
        }

        public static BrandDTO Map(this Brand brand)
        {
            return new BrandDTO
            {
                Name = brand.Name,
                Id = brand.Id,
                Image = brand.Image,
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
