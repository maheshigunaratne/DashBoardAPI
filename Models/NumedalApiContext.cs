using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace NNET_Dashboard_API.Models
{
    public partial class NumedalAPIContext : DbContext
    {
        public virtual DbSet<TShopSkiItemsApi> TShopSkiItemsApi { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }

        public NumedalAPIContext(DbContextOptions<NumedalAPIContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TShopSkiItemsApi>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationId, e.ProductId, e.OrderId, e.ProductVariantId });

                entity.ToTable("tShopSkiItems_API");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductVariantId).HasColumnName("ProductVariantID");

                entity.Property(e => e.DateofBirth).HasColumnType("datetime");

                entity.Property(e => e.Device).HasMaxLength(50);

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.PostalArea).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ProductVariantName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.ValidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.ToTable("tUser");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });
        }
    }
}
