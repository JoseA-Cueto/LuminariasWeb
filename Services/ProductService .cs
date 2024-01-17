using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return products.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            CategoryId = p.CategoryId
        });
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);
        return product != null ? new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId
        } : null;
    }

    public async Task AddProductAsync(ProductViewModel productViewModel)
    {
        var product = new Product
        {
            Name = productViewModel.Name,
            Price = productViewModel.Price,
            Description = productViewModel.Description,
            CategoryId = productViewModel.CategoryId
        };
        await _productRepository.AddProductAsync(product);
    }

    public async Task UpdateProductAsync(ProductViewModel productViewModel)
    {
        var existingProduct = await _productRepository.GetProductByIdAsync(productViewModel.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = productViewModel.Name;
            existingProduct.Price = productViewModel.Price;
            existingProduct.Description = productViewModel.Description;
            existingProduct.CategoryId = productViewModel.CategoryId;
            await _productRepository.UpdateProductAsync(existingProduct);
        }
    }

    public async Task DeleteProductAsync(int productId)
    {
        await _productRepository.DeleteProductAsync(productId);
    }
}





