using LuminariasWeb.sln.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
