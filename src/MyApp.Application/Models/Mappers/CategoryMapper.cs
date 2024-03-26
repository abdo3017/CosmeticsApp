using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
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
                ParentId = dto.ParentId
            };
        }

        public static Category Map(this CreateCategoryDTO dto)
        {
            return new Category
            {             
                Name = dto.Name,
                Description = dto.Description,
                Icon = dto.Icon,
                ParentId = dto.ParentId
            };
        }

        public static CategoryDTO Map(this Category dto)
        {
            return new CategoryDTO
            {
                Id = dto.Id,
                Name = dto.Name,
                IsSelected = dto.IsSelected,
                Description = dto.Description,
                Icon = dto.Icon
            };
        }
    }
}
