
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int productId);
        Task AddProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(ProductViewModel productViewModel);
        Task DeleteProductAsync(int productId);
    }
}
