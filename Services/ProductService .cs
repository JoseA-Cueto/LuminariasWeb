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

    public async Task AddToCartAsync(int productId, int quantityBd)
    {
        try
        {
            var product = await _repository.GetProductByIdAsync(productId);

            if (product != null)
            {
                // Verificar si hay suficientes productos en stock
                if (product.Quantity >= quantityBd)
                {
                    // Actualizar la cantidad en el carrito
                    product.Quantity -= quantityBd;

                    // Asegurarse de que la cantidad no sea negativa
                    if (product.Quantity < 0)
                    {
                        product.Quantity = 0;
                    }

                    await _repository.UpdateProductAsync(product);
                }
                else
                {
                    // Manejar la situación donde la cantidad en el carrito es mayor que la cantidad disponible
                    throw new InvalidOperationException("No hay suficientes productos en stock para agregar al carrito.");
                }
            }
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

