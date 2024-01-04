using System.Collections.Generic;
using System.Threading.Tasks;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _dbContext.Set<Product>().AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Set<Product>().Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _dbContext.Set<Product>().FindAsync(id);
            if (product != null)
            {
                _dbContext.Set<Product>().Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
