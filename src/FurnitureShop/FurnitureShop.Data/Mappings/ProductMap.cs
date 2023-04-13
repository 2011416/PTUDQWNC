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

            builder.Property(p => p.Title)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(500);

            builder.Property(p => p.Description)
                .HasMaxLength(5000);

            builder.Property(p => p.UrlSlug)
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(p => p.Meta)
             .HasMaxLength(1000)
             .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(p => p.ViewCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.PostedDate)
               .HasColumnType("datetime");

            //builder.HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryId)
            //    .HasConstraintName("FK_Products_Categories")
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p => p.Producer)
            //    .WithMany(a => a.Products)
            //    .HasForeignKey(p => p.ProducerId)
            //    .HasConstraintName("FK_Products_Producer")
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(p => p.Tags)
            //    .WithMany(t => t.Products)
            //    .UsingEntity(pt => pt.ToTable("ProductTags"));

        }
    }
}
