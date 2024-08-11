using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Context
{
    public class PaparaDbContext : IdentityDbContext<User, Role, int>
    {
        public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(r => r.Id);
            });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Coupon>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNumber)
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
                entity.Property(od => od.TotalPrice)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<OrderDetail>(entity =>
                entity.Property(od => od.UnitPrice)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<OrderDetail>(entity =>
                entity.Property(od => od.PointsEarned)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<Product>(entity =>
                entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<User>(entity =>
                entity.Property(u => u.PointsBalance)
                .HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER"
            });

            var adminUser = new User
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "papara@admin.com",
                NormalizedEmail = "PAPARA@ADMIN.COM",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true,
                PointsBalance = 0
            };

            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Papara.Admin123");

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}
