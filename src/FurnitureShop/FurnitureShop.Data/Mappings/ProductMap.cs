using FurnitureShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.UrlSlug)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Price)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Material)
          
                .HasMaxLength(100);
          
            builder.Property(p => p.Collection)
            
                .HasMaxLength(1000);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(10000);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UrlImage)
                .HasMaxLength(1000);
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Products)
                   .HasForeignKey(p => p.UserId)
                   .HasConstraintName("FK_Users_Products")
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Categories)
                .WithMany(u => u.Products)
                .UsingEntity(pu => pu.ToTable("ProductsCategories"));


        }
    }
}
