using LuminariasWeb.sln.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(Product product);
       // Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
