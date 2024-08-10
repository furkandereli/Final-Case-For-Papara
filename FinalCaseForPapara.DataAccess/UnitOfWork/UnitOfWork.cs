using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.DataAccess.Repositories.UserRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using FinalCaseForPapara.DataAccess.Repositories.ProductRepositories;
using FinalCaseForPapara.DataAccess.Repositories.CouponRepositories;
using FinalCaseForPapara.DataAccess.Repositories.OrderRepositories;

namespace FinalCaseForPapara.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PaparaDbContext _context;

        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        public ICouponRepository CouponRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }

        public UserManager<User> UserManager { get; }
        public RoleManager<Role> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }

        public UnitOfWork(PaparaDbContext context, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new GenericRepository<Category>(_context);
            ProductCategoryRepository = new GenericRepository<ProductCategory>(_context);
            OrderRepository = new OrderRepository(_context);
            OrderDetailRepository = new GenericRepository<OrderDetail>(_context);
            CouponRepository = new CouponRepository(_context);
            UserRepository = new UserRepository(_context, userManager);
            RoleRepository = new GenericRepository<Role>(_context);

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
