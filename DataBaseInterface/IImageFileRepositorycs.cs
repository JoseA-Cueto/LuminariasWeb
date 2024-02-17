using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.DataBaseInterface
{
    public interface IImageFileRepository
    {
        Task<IEnumerable<ImageFile>> GetAllAsync();
        Task<ImageFile> GetByIdAsync(int id);
        Task<ImageFile> CreateAsync(ImageFile imageFile);
        Task UpdateAsync(ImageFile imageFile);
        Task DeleteAsync(int id);
        Task<ImageFile> CreateImageFile(ImageFile entity);
        Task<ImageFile> GetImageFileByProductIdAsync(int productId);
        
        }
}

