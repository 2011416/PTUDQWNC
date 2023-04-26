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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.UrlSlug)
              .IsRequired()
              .HasMaxLength(100);
            builder.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(100);
            builder.Property(c => c.Password)
              .IsRequired()
              .HasMaxLength(100);
            builder.Property(c => c.Adress)
              .IsRequired()
              .HasMaxLength(500);
            builder.Property(c => c.phoneNumber)
              .IsRequired()
              .HasMaxLength(100);
            builder.HasOne(u => u.Role)
                 .WithMany(r => r.Users)
                 .HasForeignKey(u => u.RoleId)
                 .HasConstraintName("FK_Users_Roles")
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
