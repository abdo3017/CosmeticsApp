using MyApp.Domain.Entities;

namespace MyApp.Application.Models.DTOs
{
    public class productDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public productDTO(Product user)
        {
            Description = user.Description;
            Name = user.Name;           
        }
    }
}