using AutoMapper;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuminariasWeb.sln.BusinessInterface;
namespace LuminariasWeb.sln.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task AddProductAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductViewModel productViewModel)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productViewModel.Id);
            if (existingProduct != null)
            {
                _mapper.Map(productViewModel, existingProduct);
                await _productRepository.UpdateProductAsync(existingProduct);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }
    }
}

