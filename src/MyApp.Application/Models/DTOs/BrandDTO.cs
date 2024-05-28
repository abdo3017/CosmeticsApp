using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class BrandDTO
    {
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public byte[]? Image { get; set; }
        public int Id { get; set; }
        public ICollection<productDTO>? Products { get; set; } = new List<productDTO>();

        public ICollection<CategoryDTO>? Categories { get; set; } = new List<CategoryDTO>();
    }
}
