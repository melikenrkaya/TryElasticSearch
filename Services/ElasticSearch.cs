using Elasticsearch.Net;
using TryElasticSearch.Data.Entity;

namespace TryElasticSearch.Services
{
    public class ElasticSearch
    {
      
        private readonly ElasticLowLevelClient _client;

        public ElasticSearch(IConfiguration configuration)
        {

            var settings = new ConnectionConfiguration(new Uri("https://8c26e6e1f08d4b4c88e78244ca838893.us-central1.gcp.cloud.es.io:443"))
                .BasicAuthentication("Melikenur", "Melo398744."); // Kullanıcı adı ve şifre

            _client = new ElasticLowLevelClient(settings);

        }

        public async Task<string> SearchProductsAsync(string searchQuery)
        {
            var query = new
            {
                query = new
                {
                    match = new
                    {
                        Name = searchQuery // Arama yapılacak ürün adı alanı
                    }
                }
            };

            var response = await _client.SearchAsync<StringResponse>("products", PostData.Serializable(query));

            if (response.Success)
            {
                return response.Body.ToString();
            }
            else
            {
                return "Arama sırasında hata oluştu.";
            }
        }
        public async Task<string> AddProductToIndexAsync(Product product)
        {
            var response = await _client.IndexAsync<StringResponse>("products", PostData.Serializable(product));

            if (response.Success)
            {
                return "Ürün başarıyla eklendi!";
            }
            else
            {
                Console.WriteLine("Hata: " + response.DebugInformation);
                return "Ürün eklenirken hata oluştu.";

            }
        }


    }

}
