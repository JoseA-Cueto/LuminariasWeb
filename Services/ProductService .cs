using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

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
        try
        {
            var products = await _repository.GetAllProductsAsync();
            return _mapper.Map<List<Product>>(products);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        try
        {
            var product = await _repository.GetProductByIdAsync(productId);
            return _mapper.Map<Product>(product);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task AddProductAsync(ProductViewModel productViewModel)
    {
        try
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _repository.AddProductAsync(product);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task UpdateProductAsync(ProductViewModel productViewModel)
    {
        try
        {
            var updatedProduct = _mapper.Map<Product>(productViewModel);
            await _repository.UpdateProductAsync(updatedProduct);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task DeleteProductAsync(int productId)
    {
        try
        {
            await _repository.DeleteProductAsync(productId);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

   


    private void HandleException(Exception ex)
    {
        Console.WriteLine($"Se produjo una excepción en ProductService: {ex.Message}");
    }
}

