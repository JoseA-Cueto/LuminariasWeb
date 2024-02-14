using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IImageFileService
    {
        Task<ImageFilesViewModel> CreateImageFile(ImageFilesViewModel model);
        Task<ImageFilesViewModel> UploadImage(ImageFilesViewModel entity, string path);
        Task Create(ImageFilesViewModel entity);
        Task Delete(int id);
        Task<ImageFilesViewModel> Find(int id);
        Task<IEnumerable<ImageFilesViewModel>> GetAll();
        Task Update(ImageFilesViewModel entity);
        Task UpdateImageProduct(ImageFilesViewModel entity, string path);
        Task<bool> ExistImageByPath(string path);
    }
}
