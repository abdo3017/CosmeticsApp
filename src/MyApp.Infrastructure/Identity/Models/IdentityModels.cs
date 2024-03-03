using Microsoft.AspNetCore.Identity;

namespace MyApp.Infrastructure.Identity.Models
{

    public class AppUser :IdentityUser<int>
    {
        
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
