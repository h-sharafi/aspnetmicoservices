using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var httpClientResult = await _client.GetAsync($"/api/v1/basket/{userName}");
            return await httpClientResult.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}