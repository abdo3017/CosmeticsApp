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
        public int Id { get; set; }
        //public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
