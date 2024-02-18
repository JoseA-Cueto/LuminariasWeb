public interface ICartService
{
    public Task AddItemToCartAsync(CartItemViewModel item);
    public Task<ShoppingCartViewModel> GetShoppingCartAsync();
    Task ProcessPurchaseAsync(ShoppingCartViewModel cart);
    Task CancelPurchaseAsync(ShoppingCartViewModel cart);


}