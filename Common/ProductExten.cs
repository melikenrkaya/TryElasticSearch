using TryElasticSearch.Data.Entity;
using TryElasticSearch.Data.Models;

namespace TryElasticSearch.Common
{
    public static class ProductExten
    {
        public static ProductDto ToProductDto(this Product ProductModel)
        {
            return new ProductDto
            {
                Id = ProductModel.Id,
                Name = ProductModel.Name,
                Description = ProductModel.Description,
                Price = ProductModel.Price,
                Stock = ProductModel.Stock,
            };
        }
        public static Product ToProductFromCreatedDTO(this CreateProductRequestDto createproductDto,int id)
        {
            return new Product
            {
                Name = createproductDto.Name,
                Description = createproductDto.Description,
                Price = createproductDto.Price,
                Stock = createproductDto.Stock
,
            };
        }
    }
}
