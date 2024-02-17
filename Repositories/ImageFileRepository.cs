using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly AppDbContext _context;

        public ImageFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImageFile>> GetAllAsync()
        {
            return await _context.ImageFiles.ToListAsync();
        }

        public async Task<ImageFile> GetByIdAsync(int id)
        {
            return await _context.ImageFiles.FindAsync(id);
        }

        public async Task<ImageFile> CreateAsync(ImageFile imageFile)
        {
            _context.ImageFiles.Add(imageFile);
            await _context.SaveChangesAsync();
            return imageFile;
        }
        public async Task<ImageFile> CreateImageFile(ImageFile entity)
        {
            
                entity.CreateDate = DateTime.Now;
                var imageFileEntry = _context.ImageFiles.Add(entity);
                await _context.SaveChangesAsync();
                return imageFileEntry.Entity; 
            

        }
        public async Task<ImageFile> GetImageFileByProductIdAsync(int productId)
        {
           
            return await _context.ImageFiles.FirstOrDefaultAsync(f => f.ProductId == productId);
        }


        public async Task UpdateAsync(ImageFile imageFile)
        {
            _context.Entry(imageFile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var imageFile = await _context.ImageFiles.FindAsync(id);
            if (imageFile != null)
            {
                _context.ImageFiles.Remove(imageFile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
