using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Models;
namespace LuminariasWeb.sln.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItemViewModel> _cartItems;
        private readonly IProductService _productService;


        public CartService(IProductService productService)
        {
            _cartItems = new List<CartItemViewModel>();
            _productService = productService;
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
        public async Task ProcessPurchaseAsync(ShoppingCartViewModel cart)
        {
            foreach (var item in cart.Items)
            {
                var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity -= item.Quantity;
                    await _productService.UpdateProductQuantityAsync(existingItem.ProductId, -item.Quantity);
                }
            }

           
        }

        public async Task CancelPurchaseAsync(ShoppingCartViewModel cart)
        {
            foreach (var item in cart.Items)
            {
                var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    await _productService.UpdateProductQuantityAsync(existingItem.ProductId, item.Quantity);
                }
            }

            
        }

    }
}