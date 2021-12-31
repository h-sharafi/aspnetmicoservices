using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var httpClientResult = await _client.GetAsync("/api/v1/Catalog");
            return await httpClientResult.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var httpClientResult = await _client.GetAsync($"/api/v1/Catalog/{id}");
            return await httpClientResult.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            //GetProductByCategory
            var httpClientResult = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await httpClientResult.ReadContentAs<List<CatalogModel>>();
        }
    }
}