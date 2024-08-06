﻿using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Repositories.ProductRepositories
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

        public async Task ToggleActiveStatusAsync(string productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                product.Stock = !product.Stock;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleStockStatusAsync(string productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                product.IsActive = !product.IsActive;
                await _context.SaveChangesAsync();
            }
        }
    }
}
