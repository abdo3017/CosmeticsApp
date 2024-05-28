using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using MyApp.Infrastructure.Data.Configurations;
using MyApp.Infrastructure.Identity.Models;
using MyApp.Infrastructure.Models;
using System.Text.RegularExpressions;

using Attribute = MyApp.Domain.Entities.Attribute;

namespace MyApp.Infrastructure.Data
{
    public class MyAppDbContext : IdentityDbContext<Identity.Models.AppUser, Identity.Models.AppRole, int>
    {

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        { }

        public virtual DbSet<ShipmentCost> shipmentCost { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Advertisement> Advertisements { get; set; }

        public virtual DbSet<User> Users { get; set; }

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
        public virtual DbSet<CardToken> CardTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EfConfig.ConfigureEf(modelBuilder);


        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            try
            {
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                ChangeTracker.Clear();
                SqlException innerException = (ex.InnerException?.InnerException as SqlException) ?? ex.InnerException as SqlException;
                if (innerException != null && (innerException?.Number == 2627 || innerException?.Number == 2601))
                {
                    throw new Exception("DuplicateKeyError");
                }
                else
                {
                    throw;
                }
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            try
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (DbUpdateException ex)
            {
                ChangeTracker.Clear();
                SqlException innerException = (ex.InnerException?.InnerException as SqlException) ?? ex.InnerException as SqlException;
                if (innerException != null && (innerException?.Number == 2627 || innerException?.Number == 2601))
                {
                    throw new Exception("DuplicateKeyError");
                }
                else
                {
                    throw;
                }
            }

        }
        private void TrySaving()
        {

        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;
            //string userName = CurrentBUClass.GetUserName();

            foreach (var entry in entries.Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                var TheEntity = entry.Entity;
                try
                {
                    if (TheEntity != null)
                    {
                        var ModifiedOnProp = entry.Properties.Where(x =>
                               string.Equals(x.Metadata.Name, "ModifiedOn", StringComparison.OrdinalIgnoreCase)
                                || string.Equals(x.Metadata.Name, "ModificationDate", StringComparison.OrdinalIgnoreCase))
                            .FirstOrDefault();
                        var ModifiedByProp = entry.Properties.Where(x =>
                               string.Equals(x.Metadata.Name, "ModifiedBy", StringComparison.OrdinalIgnoreCase))
                            .FirstOrDefault();
                        var CreatedOnProp = entry.Properties.Where(x =>
                              string.Equals(x.Metadata.Name, "CreatedOn", StringComparison.OrdinalIgnoreCase)
                              || string.Equals(x.Metadata.Name, "CreationDate", StringComparison.OrdinalIgnoreCase))
                            .FirstOrDefault();
                        var CreatedbyProp = entry.Properties.Where(x =>
                             string.Equals(x.Metadata.Name, "CreatedBy", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();


                        switch (entry.State)
                        {
                            case EntityState.Modified:
                                SetPropertyValue(ModifiedOnProp, utcNow);
                                SetPropertyValue(ModifiedByProp, "");
                                if (CreatedOnProp != null)
                                    CreatedOnProp.IsModified = false;
                                if (CreatedbyProp != null)
                                    CreatedbyProp.IsModified = false;
                                break;

                            case EntityState.Added:
                                if (ModifiedByProp != null)
                                    ModifiedByProp.CurrentValue = null;
                                if (ModifiedOnProp != null)
                                    ModifiedOnProp.CurrentValue = null;

                                SetPropertyValue(CreatedOnProp, utcNow);
                                SetPropertyValue(CreatedbyProp, "");
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
        private void SetPropertyValue(PropertyEntry property, object value)
        {
            if (property != null)
                property.CurrentValue = value;
        }

    }
}
