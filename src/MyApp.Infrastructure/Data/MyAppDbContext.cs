using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data.Configurations;
using MyApp.Infrastructure.Identity.Models;
using Attribute = MyApp.Domain.Entities.Attribute;

namespace MyApp.Infrastructure.Data
{
    public class MyAppDbContext : IdentityDbContext<AppUser,AppRole,int>
    {

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }

        public virtual DbSet<AttributeValue> AttributeValues { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartDetail> CartDetails { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Customer_Address> Customer_Addresses { get; set; }

        public virtual DbSet<Gallery> Galleries { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EfConfig.ConfigureEf(modelBuilder);
            

        }

    }
}
