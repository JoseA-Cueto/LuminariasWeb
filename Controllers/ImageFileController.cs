using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace LuminariasWeb.sln.Controllers
{
    [Route("api/ImageFile")]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageFileService _imageFileService;
        private readonly ILogger<ImageFileController> _logger;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ImageFileController(IImageFileService imageFileService, ILogger<ImageFileController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _imageFileService = imageFileService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

 

 
        [HttpPost("CreateImageFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateImageFile(IFormFile file)
        {
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

                await _imageFileService.Create(new ImageFilesViewModel
                {
                    CreateDate = DateTime.Now,
                    Path = $"{relativePath}{fileNameResult}",
                    PhysicalPath = $"{physicalPath}",
                    ContentType = "data:" + file.ContentType,
                    Size = (int)file.Length,
                    Name = fileNameResult
                });

                return Ok();
            }
            return BadRequest();
        }


       
    }
}

