using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class BrandDTO
    {
        public string? Name { get; set; }
        public byte?[] Image { get; set; } = null!;
        public int Id { get; set; }
        public ICollection<productDTO> Products { get; set; } = new List<productDTO>();

        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
