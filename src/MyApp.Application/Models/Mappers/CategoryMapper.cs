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
    public static class CategoryMapper
    {
        public static Category Map(this CategoryDTO dto)
        {
            return new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Icon = dto.Icon,
                IsSelected = dto.IsSelected,
                ParentId = dto.ParentId,
                NameAr = dto.NameAr,
                DescriptionAr = dto.DescriptionAr,
            };
        }

        public static Category Map(this CreateCategoryDTO dto)
        {
            return new Category
            {             
                Name = dto.Name,
                Description = dto.Description,
                Icon = dto.Icon,
                ParentId = dto.ParentId,
                IsSelected = dto.IsSelected,
                NameAr = dto.NameAr,
                DescriptionAr = dto.DescriptionAr
            };
        }

        public static CategoryDTO Map(this Category dto)
        {
            return new CategoryDTO
            {
                Id = dto.Id,
                Name = CultureInfo.CurrentCulture.Name == "en" ? dto.Name :dto.NameAr,
                Description = CultureInfo.CurrentCulture.Name == "en" ? dto.Description : dto.DescriptionAr,
                IsSelected = dto.IsSelected,
                Icon = dto.Icon,
                Img = dto.Image
            };
        }

        public static SearchResult MapTOSearchResult(this Category dto)
        {
            return new SearchResult
            {

                Name = CultureInfo.CurrentCulture.Name == "en" ? dto.Name : dto.NameAr,
                Key = dto.Id,
                Type = SearchResultType.Categort
            };
        }
    }
}
