﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Models;

namespace MyApp.Infrastructure.Identity.Models
{

    public partial class AppUser :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int roleId { get; set; }

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
