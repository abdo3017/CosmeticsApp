using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Models;

namespace MyApp.Infrastructure.Identity.Models
{

    public partial class AppUser :IdentityUser<int>
    {
        public List<RefreshToken>? RefreshTokens { get; set; }
    }


    public class AppRole : IdentityRole<int>
    {
        public AppRole()
        {
        }

        public AppRole(string name)
        {
            Name = name;
        }
    }

    public class AppUserRole : IdentityUserRole<int>
    {
    }

    public class AppUserClaim : IdentityUserClaim<int>
    {
    }


    public class AppUserLogin : IdentityUserLogin<int>
    {
    }
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}
