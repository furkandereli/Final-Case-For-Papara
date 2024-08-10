using FinalCaseForPapara.DataAccess.Repositories.CouponRepositories;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.DataAccess.Repositories.OrderRepositories;
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
        IOrderRepository OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        ICouponRepository CouponRepository { get; }
        IUserRepository UserRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }

        UserManager<User> UserManager { get; }
        RoleManager<Role> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
    }
}
