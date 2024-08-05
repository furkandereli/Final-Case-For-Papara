using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.GenericRepository;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.ProductRepositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PaparaDbContext context) : base(context) { }

        public async Task<List<Product>> GetProductsWithCategoriesAsync()
        {
            return await _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }
    }
}
