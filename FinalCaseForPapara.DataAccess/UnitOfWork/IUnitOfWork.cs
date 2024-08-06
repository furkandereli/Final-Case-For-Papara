using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.DataAccess.Repositories.ProductRepositories;
using FinalCaseForPapara.DataAccess.Repositories.UserRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalCaseForPapara.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        IProductRepository ProductRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<Coupon> CouponRepository { get; }
        IUserRepository UserRepository { get; }

        UserManager<User> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
    }
}
