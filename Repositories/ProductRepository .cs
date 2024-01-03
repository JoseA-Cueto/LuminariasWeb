using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Set<Product>().Find(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Set<Product>().ToList();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Set<Product>().Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Set<Product>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Product>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
