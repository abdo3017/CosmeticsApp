using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public bool IsSelected { get; set; }
        public int? ParentId { get; set; }
        public ICollection<CategoryDTO> SubCategories { get; set; } = new HashSet<CategoryDTO>();

    }
}
