using TryElasticSearch.Data.Context;
using TryElasticSearch.Data.Entity;
using TryElasticSearch.Data.Models;

namespace TryElasticSearch.Services.ProductServices
{
    public interface IProductServi
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> CreateAsync(Product product);
        Task<Product> DeleteProductAsync(int id);
        Task<List<Product>> SearchProductsAsync(string query);

    }

}



