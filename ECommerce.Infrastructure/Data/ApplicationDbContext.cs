using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ECommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductCategoryMap> ProductCategoriesMap { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderDetail>()
                .HasOne<Order>(od => od.Order)
                .WithMany(o => o.Details)
                .HasForeignKey(od => od.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne<Product>(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            builder.Entity<Order>()
                .HasOne<ApplicationUser>(o => o.User)
                .WithMany(au => au.Orders)
                .HasForeignKey(o => o.UserId);

            builder.Entity<ProductCategoryMap>()
                        .HasKey(bc => new { bc.ProductId, bc.CategoryId });

            builder.Entity<ProductCategoryMap>()
                .HasOne<Product>(bc => bc.Product)
                .WithMany(b => b.CategoryMap)
                .HasForeignKey(bc => bc.ProductId);

            builder.Entity<ProductCategoryMap>()
              .HasOne<Category>(bc => bc.Category)
              .WithMany(b => b.ProductsMap)
              .HasForeignKey(bc => bc.CategoryId);

            builder.Entity<Comment>()
                .HasOne<ApplicationUser>(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            builder.Entity<Comment>()
                .HasOne<Product>(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);
        }


    }
}