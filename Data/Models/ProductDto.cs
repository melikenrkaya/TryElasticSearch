namespace TryElasticSearch.Data.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = int.MaxValue;
        public int Stock { get; set; } = int.MaxValue;


    }
    public class CreateProductRequestDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = int.MaxValue;
        public int Stock { get; set; } = int.MaxValue;


    }

    public class UpdateProductRequestDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = int.MaxValue;
        public int Stock { get; set; } = int.MaxValue;


    }


}
