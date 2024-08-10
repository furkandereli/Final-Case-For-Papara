using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.Repositories.ProductRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductsByIdWithCategoriesAsync(int id);
        Task<List<Product>> GetProductsWithCategoriesAsync();
        Task ToggleStockStatusAsync(int productId);
        Task ToggleActiveStatusAsync(int productId);
    }
}
