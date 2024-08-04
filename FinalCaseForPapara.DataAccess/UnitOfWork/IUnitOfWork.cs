using FinalCaseForPapara.DataAccess.GenericRepository;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<Coupon> CouponRepository { get; }
        IGenericRepository<User> UserRepository { get; }
    }
}
