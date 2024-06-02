using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class AuthModel
    {
        public int? UserId { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public RoleType Role { get; set; }
        public string? Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

    }
}
