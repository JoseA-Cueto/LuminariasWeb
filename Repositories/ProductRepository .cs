using System.Collections.Generic;
using System.Threading.Tasks;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<int> AddProductAsync(Product product)
        {   
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        //public async Task UpdateProductAsync(Product product)
        //{
        //    // Si la imagen ha sido actualizada, asegúrate de actualizar la propiedad ImagePath
        //    var existingProduct = await _context.Products.FindAsync(product.Id);
        //    if (existingProduct != null && !string.IsNullOrEmpty(product.ImagePath))
        //    {
        //        existingProduct.ImagePath = product.ImagePath;
        //    }

        //    // Actualiza las demás propiedades y guarda los cambios
        //    _context.Entry(existingProduct).CurrentValues.SetValues(product);
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}

