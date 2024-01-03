using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await _repository.GetAllProductsAsync();
        return _mapper.Map<List<Product>>(products);
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        var product = await _repository.GetProductByIdAsync(productId);
        return _mapper.Map<Product>(product);
    }

    public async Task AddProductAsync(ProductViewModel productViewModel)
    {
        var product = _mapper.Map<Product>(productViewModel);
        await _repository.AddProductAsync(product);
    }

    public async Task UpdateProductAsync(ProductViewModel productViewModel)
    {
        var updatedProduct = _mapper.Map<Product>(productViewModel);
        await _repository.UpdateProductAsync(updatedProduct);
    }

    public async Task DeleteProductAsync(int productId)
    {
        await _repository.DeleteProductAsync(productId);
    }
}
