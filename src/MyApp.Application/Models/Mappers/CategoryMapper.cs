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
                Name = dto.Name,
                Description = dto.Description,
                Icon = dto.Icon
            };
        }

        public static CategoryDTO Map(this Category dto)
        {
            return new CategoryDTO
            {
                Name = dto.Name,
                Description = dto.Description,
                Icon = dto.Icon
            };
        }
    }
}
