using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _rediceCatch;

        public BasketRepository(IDistributedCache rediceCatch)
        {
            this._rediceCatch = rediceCatch;
        }
        public async Task DeleteBasket(string userName)
        {
           await _rediceCatch.RemoveAsync(userName);

        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _rediceCatch.GetStringAsync(userName);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
         
           await _rediceCatch.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
        }
    }
}
