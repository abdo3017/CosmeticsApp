using MyApp.Domain.Entities;

namespace MyApp.Application.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailId = user.EmailId;
           
        }
    }
}