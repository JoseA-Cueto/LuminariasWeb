using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuminariasWeb.sln.Services
{
    public class ImageFileService : IImageFileService
    {
        private readonly IImageFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;


        public ImageFileService(IImageFileRepository repository, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<ImageFile> CreateImageFile(ProductViewModel product)
        {
            var file = product.File;
            string[] extension = { ".jpg", ".jpeg", ".bmp", ".png", ".tif", ".ico", ".tiff", ".pjpeg" };
            var fileName = file.FileName;

            if (extension.Any(a => a.ToUpper() == Path.GetExtension(fileName).ToUpper()))
            {
                string pathRoot = Path.Combine(_hostingEnvironment.WebRootPath, "Upload", "ImageFile");

                if (!Directory.Exists(pathRoot))
                {
                    Directory.CreateDirectory(pathRoot);
                }
                var splitedFileName = file.FileName.Split('.');
                var fileNameResult = $"{String.Join(" ", splitedFileName, 0, splitedFileName.Length - 1)}-D{DateTime.Now.ToString("yyyy-MM-dd HHmm")}{Path.GetExtension(file.FileName)}";
                var relativePath = "Upload/ImageFile/";
                var physicalPath = Path.Combine(pathRoot, fileNameResult);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

               var imageFile = await Create(new ImageFilesViewModel
                {
                    CreateDate = DateTime.Now,
                    Path = $"{relativePath}{fileNameResult}",
                    PhysicalPath = $"{physicalPath}",
                    ContentType = "data:" + file.ContentType,
                    Size = (int)file.Length,
                    Name = fileNameResult,
                    ProductId = product.Id,
                });

                return imageFile;
            }
            return null;
        }


        public async Task<ImageFile> Create(ImageFilesViewModel entity)
        {
            
               return await _repository.CreateAsync(_mapper.Map<ImageFile>(entity));
            
           
            
        }
       
    }
}
