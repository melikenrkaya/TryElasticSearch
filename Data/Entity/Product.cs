namespace TryElasticSearch.Data.Entity
{
    public class Product
    {
            public int Id { get; set; } // Ürün ID'si
            public string Name { get; set; } // Ürün adı
            public string Description { get; set; } // Ürün açıklaması
            public decimal Price { get; set; } // Ürün fiyatı
            public int Stock { get; set; } // Ürün stoğu

    }
}
