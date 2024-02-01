public interface ICartService
{
    void AddToCart(CartViewModel item);
    List<CartViewModel> GetCartItems();
   
}