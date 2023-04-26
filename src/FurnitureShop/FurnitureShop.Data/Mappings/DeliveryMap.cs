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
    public class DeliveryMap : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deliveries");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c=> c.UrlSlug)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c=> c.Date)
                .HasColumnType("datetime");
              builder.HasOne(d=> d.User)
                .WithMany(u=> u.Deliveries)
                .HasForeignKey(d=> d.UserId)
                .HasConstraintName("FK_Users_Deliveries")
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
