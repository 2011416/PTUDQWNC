using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Data.Contexts
{
    public class BlogDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public BlogDbContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=XUANHUNG;Database=FurnitureShop;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(CategoryMap).Assembly);
        }

    }
}
