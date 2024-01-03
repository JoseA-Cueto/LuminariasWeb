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
    public List<Product> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        return _mapper.Map<List<Product>>(products);
    }

    public Product GetProductById(int productId)
    {
        var product = _repository.GetProductById(productId);
        return _mapper.Map<Product>(product);
    }

    public void AddProduct(ProductViewModel productViewModel)
    {
        var product = _mapper.Map<Product>(productViewModel);
        _repository.AddProduct(product);
    }

    public void UpdateProduct(ProductViewModel productViewModel)
    {
        var updatedProduct = _mapper.Map<Product>(productViewModel);
        _repository.UpdateProduct(updatedProduct);
    }

    public void DeleteProduct(int productId)
    {
        _repository.DeleteProduct(productId);
    }

}