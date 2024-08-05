using FinalCaseForPapara.DataAccess.GenericRepository;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.ProductRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoriesAsync();
    }
}
