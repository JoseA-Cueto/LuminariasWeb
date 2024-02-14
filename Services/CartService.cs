using LuminariasWeb.sln.Models;
namespace LuminariasWeb.sln.Services {
    public class CartService : ICartService
    {
        private List<CartViewModel> cartItems = new List<CartViewModel>();
        private readonly AppDbContext dbContext;

        public CartService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddToCart(CartViewModel item)
        {

            Product product = dbContext.Products.Find(item.Product.Id);


            item.Product = product;


            cartItems.Add(item);
        }

        public List<CartViewModel> GetCartItems()
        {

            return cartItems;
        }
    }
   
}