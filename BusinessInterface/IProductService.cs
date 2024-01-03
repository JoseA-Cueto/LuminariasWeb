using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        void AddProduct(ProductViewModel productViewModel);
        void UpdateProduct(ProductViewModel productViewModel);
        void DeleteProduct(int productId);
    }
}
