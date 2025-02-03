using Microsoft.EntityFrameworkCore;
using ProductsServer.Domain;
using ProductsServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        internal DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        internal DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<ProductCategoryEntity>()
                .HasKey(pc => pc.Id);

            modelBuilder.Entity<ProductEntity>()
                .HasKey(p => p.Id);

            // Define foreign key
            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.ProductCategory)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
