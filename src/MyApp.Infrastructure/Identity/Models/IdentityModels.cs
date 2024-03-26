using Microsoft.AspNetCore.Identity;
using MyApp.Infrastructure.Models;

namespace MyApp.Infrastructure.Identity.Models
{

    public class AppUser :IdentityUser<int>
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
}
