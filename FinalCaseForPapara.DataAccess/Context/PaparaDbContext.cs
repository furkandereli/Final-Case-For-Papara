using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Context
{
    public class PaparaDbContext : IdentityDbContext
    {
        public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options) { }

        public new DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>()
                .HasIndex(c => c.Code)
                .IsUnique();

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

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            });

            var adminUser = new User
            {
                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "papara@admin.com",
                NormalizedEmail = "PAPARA@ADMIN.COM",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true,
                WalletBalance = 0,
                PointsBalance = 0
            };

            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "PaparaAdmin123");

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });
        }
    }
}
