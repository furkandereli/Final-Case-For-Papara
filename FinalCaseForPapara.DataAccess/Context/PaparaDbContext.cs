using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Context
{
    public class PaparaDbContext : IdentityDbContext<User>
    {
        public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<Order>(entity =>
                entity.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<Order>(entity =>
                entity.Property(o => o.CouponAmount)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<Order>(entity =>
                entity.Property(o => o.PointsUsed)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<OrderDetail>(entity =>
                entity.Property(od => od.Price)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<Product>(entity =>
                entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<User>(entity =>
                entity.Property(u => u.WalletBalance)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<User>(entity =>
                entity.Property(u => u.PointsBalance)
                .HasColumnType("decimal(18,2)"));
        }
    }
}
