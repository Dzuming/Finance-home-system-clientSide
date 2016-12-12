using System.Linq;
using finance_home_system.Categories;
using finance_home_system.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Api.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .ToTable("Category");
            modelBuilder.Entity<Product>()
          .ToTable("Product");
            modelBuilder.Entity<Product>()
                .HasOne(p => p.categories)
                .WithMany()
                .HasForeignKey(p => p.categoryId);
            modelBuilder.Entity<Product>()
            .Property(s => s.DateCreated)
            .HasDefaultValue(DateTime.Today.ToString("yyyy-MM-dd"));
        }
    }
}

