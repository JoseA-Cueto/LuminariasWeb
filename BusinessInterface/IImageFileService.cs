using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IImageFileService
    {
        Task<ImageFile> CreateImageFile(ProductViewModel product);
       
        Task <ImageFile>Create(ImageFilesViewModel entity);
        Task UpdateImageFile(ProductViewModel productViewModel);
        Task<ImageFile> GetImageByProductIdAsync(int productId);
        Task DeleteImageFileAsync(int imageId);
    }
}
