using Microsoft.EntityFrameworkCore;
using Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(a => a.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(a => a.ProductCost).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(a => a.ProductDescription).HasColumnType("nvarchar(200)");


            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.ImgId);
                entity.Property(u => u.ImgUrl).IsRequired();
                entity
                    .HasOne(a => a.Product)
                    .WithMany(i => i.ProductImages)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryName).IsRequired().HasColumnType("nvarchar(100)");
                entity.Property(c => c.CategoryDescription).HasColumnType("nvarchar(200)");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.CategoryId });

                entity
                    .HasOne(p => p.Product)
                    .WithMany(pc => pc.ProductCategories)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.NoAction)
                    ;

                entity
                    .HasOne(c => c.Category)
                    .WithMany(pc => pc.ProductCategories)
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ProductName>(entity =>
            {
                entity.HasKey(i => i.ProductNameId);
                entity.Property(u => u.LanguageCode).IsRequired().HasColumnType("nvarchar(10)");
                entity.Property(u => u.Text).IsRequired().HasColumnType("nvarchar(100)");
                entity
                    .HasOne(a => a.Product)
                    .WithMany(i => i.ProductNames)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
