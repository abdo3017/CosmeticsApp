using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Attribute = MyApp.Domain.Entities.Attribute;

namespace MyApp.Infrastructure.Data.Configurations
{
    public class EfConfig
    {
        public static void ConfigureEf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Attribute).WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeValues_Attributes");

                entity.HasOne(d => d.Product).WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AttributeValues_Products");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasMany(d => d.Categories).WithMany(p => p.Brands)
                    .UsingEntity<Dictionary<string, object>>(
                        "Brand_Category",
                        r => r.HasOne<Category>().WithMany()
                            .HasForeignKey("CategoryId")
                            .HasConstraintName("FK_Brand_Category_Categories"),
                        l => l.HasOne<Brand>().WithMany()
                            .HasForeignKey("BrandId")
                            .HasConstraintName("FK_Brand_Category_Brands"),
                        j =>
                        {
                            j.HasKey("BrandId", "CategoryId");
                            j.ToTable("Brand_Category");
                        });
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CustomerId).HasMaxLength(455);
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_CartDetails_Carts");

                entity.HasOne(d => d.Product).WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartDetails_Products");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(20);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer_Address>(entity =>
            {
                entity.ToTable("Customer_Address");

                entity.Property(e => e.Area).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(255);
                entity.Property(e => e.Country).HasMaxLength(255);
                entity.Property(e => e.CustomerId).HasMaxLength(455);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CustomerId).HasMaxLength(455);
                entity.Property(e => e.DeliveredAt).HasColumnType("datetime");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.RateValue).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");
            });
        }
    }

}
