namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        public List<ShopingCartItems> Items { get; set; } = new List<ShopingCartItems>();
        public decimal TotalPrice
        {
            get
            {
              return Items.Sum(item => item.Price * item.Quantity);
               
            }
        }
    }
}
