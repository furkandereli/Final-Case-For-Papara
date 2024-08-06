using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.DataAccess.Repositories.ProductRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoriesAsync();
        Task ToggleStockStatusAsync(string productId);
        Task ToggleActiveStatusAsync(string productId);
    }
}
