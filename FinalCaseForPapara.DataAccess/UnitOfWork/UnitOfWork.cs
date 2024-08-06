using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.DataAccess.Repositories.UserRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using FinalCaseForPapara.DataAccess.Repositories.ProductRepositories;

namespace FinalCaseForPapara.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PaparaDbContext _context;

        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        public IGenericRepository<Order> OrderRepository { get; }
        public IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        public IGenericRepository<Coupon> CouponRepository { get; }

        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }

        public UnitOfWork(PaparaDbContext context, 
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new GenericRepository<Category>(_context);
            ProductCategoryRepository = new GenericRepository<ProductCategory>(_context);
            OrderRepository = new GenericRepository<Order>(_context);
            OrderDetailRepository = new GenericRepository<OrderDetail>(_context);
            CouponRepository = new GenericRepository<Coupon>(_context);
            UserRepository = new UserRepository(_context, userManager);

            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
