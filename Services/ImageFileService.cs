

using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.Services
{
    public class ImageFileService : IImageFileService
    {
        private readonly IImageFileRepository _repository;
        private readonly IMapper _mapper;


        public ImageFileService(IImageFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
           
        }

        public async Task<ImageFilesViewModel> CreateImageFile(ImageFilesViewModel model)
        {
           
                var entity = _mapper.Map<ImageFilesViewModel>(model);
                var result = await _repository.CreateImageFile(_mapper.Map<ImageFile>(entity));
                return _mapper.Map<ImageFilesViewModel>(result);
           
        }

        public async Task<ImageFilesViewModel> UploadImage(ImageFilesViewModel entity, string path)
        {
            var result = new ImageFile();
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + entity.Name;
            entity.Name = fileName;
            var pathC = Path.Combine(path, @"Upload\\ImageFile\\" + fileName);

            if (entity.Content.Contains(","))
            {
                entity.Content = entity.Content.Substring(entity.Content.IndexOf(",") + 1);
                byte[] imgBytes = Convert.FromBase64String(entity.Content);

                entity.CreateDate = DateTime.Now;
                entity.Path = @"/Upload/ImageFile/" + fileName;
                entity.PhysicalPath = pathC;

                if (!Directory.Exists(path + @"\\Upload\\ImageFile\\"))
                {
                    Directory.CreateDirectory(path + @"\\Upload\\ImageFile\\");
                }

                if (!System.IO.File.Exists(pathC))
                {
                    using (var fs = new FileStream(pathC, FileMode.CreateNew))
                    {
                        await fs.WriteAsync(imgBytes, 0, imgBytes.Length);
                    }

                    result = await _repository.CreateImageFile(_mapper.Map<ImageFile>(entity));
                }
            }

            return _mapper.Map<ImageFilesViewModel>(result);
        }


        public async Task Create(ImageFilesViewModel entity)
        {
            
                await _repository.CreateAsync(_mapper.Map<ImageFile>(entity));
           
            
        }
        public async Task Delete(int id)
        {
           
                await _repository.DeleteAsync(id);
         
        }

        public async Task<ImageFilesViewModel> Find(int id)
        {
            
                var obj = await _repository.GetByIdAsync(id);
                return _mapper.Map<ImageFilesViewModel>(obj);
            
           
        }

        public async Task<IEnumerable<ImageFilesViewModel>> GetAll()
        {
            
                var imageFile = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ImageFilesViewModel>>(imageFile);
            
            
        }

        public async Task Update(ImageFilesViewModel entity)
        {
            
                entity.CreateDate = DateTime.Now;
                await _repository.UpdateAsync(_mapper.Map<ImageFile>(entity));
            
           
        }

        public async Task UpdateImageProduct(ImageFilesViewModel entity, string path)
        {
            
                var fileNameSplited = entity.Name.Split('.');
                entity.Path = $"{entity.PhysicalPath}.{fileNameSplited[fileNameSplited.Length - 1]}";
                entity.PhysicalPath = Path.Combine(path, @"Image\\ClientCode\\" + $"{entity.PhysicalPath.Split('/').Last()}.{fileNameSplited[fileNameSplited.Length - 1]}");
                entity.CreateDate = DateTime.Now;
                await _repository.UpdateAsync(_mapper.Map<ImageFile>(entity));
            
            
        }

        public async Task<bool> ExistImageByPath(string path)
        {
            return File.Exists(path);
        }
    }
}
