using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.GenericRepository;
using FinalCaseForPapara.DataAccess.ProductRepositories;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PaparaDbContext _context;

        public IProductRepository ProductRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        public IGenericRepository<Order> OrderRepository { get; }
        public IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        public IGenericRepository<Coupon> CouponRepository { get; }
        public IGenericRepository<User> UserRepository { get; }

        public UnitOfWork(PaparaDbContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new GenericRepository<Category>(_context);
            ProductCategoryRepository = new GenericRepository<ProductCategory>(_context);
            OrderRepository = new GenericRepository<Order>(_context);
            OrderDetailRepository = new GenericRepository<OrderDetail>(_context);
            CouponRepository = new GenericRepository<Coupon>(_context);
            UserRepository = new GenericRepository<User>(_context);
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
