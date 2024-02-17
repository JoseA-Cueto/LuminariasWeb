using LuminariasWeb.sln.Models;
namespace LuminariasWeb.sln.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItemViewModel> _cartItems;


        public CartService()
        {
            _cartItems = new List<CartItemViewModel>();
        }
        public Task AddItemToCartAsync(CartItemViewModel item)
        {
            return Task.Run(() =>
            {
                var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    _cartItems.Add(item);
                }
            });
        }

        public Task<ShoppingCartViewModel> GetShoppingCartAsync()
        {
            return Task.Run(() =>
            {
                decimal totalPrice = _cartItems.Sum(item => item.Price * item.Quantity);

                var shoppingCart = new ShoppingCartViewModel
                {
                    Items = _cartItems,
                    TotalPrice = totalPrice
                };

                return shoppingCart;
            });
        }

    }
}