using Microsoft.EntityFrameworkCore;
using System;
using TryElasticSearch.Data.Context;
using TryElasticSearch.Data.Entity;
using TryElasticSearch.Data.Models;

namespace TryElasticSearch.Services.ProductServices
{
    public class ProductServi : IProductServi
    {
        private readonly ApplicationDBContext _context;

        public ProductServi(ApplicationDBContext context)
        {
            _context = context;
        }

        // Ürün listeleme
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Ürün ekleme
        public async Task<Product?> CreateAsync(Product ProductModel)
        {
            await _context.Products.AddAsync(ProductModel);
            await _context.SaveChangesAsync();
            return ProductModel;
        }

        // Ürün silme
        public async Task<Product> DeleteProductAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        // Ürün arama (örneğin, isme göre)
        public async Task<List<Product>> SearchProductsAsync(string query)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(query))
                .ToListAsync();
        }

    }

}

