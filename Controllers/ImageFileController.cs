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

        [HttpGet("GetAllImageFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ImageFilesViewModel>>> GetAllImageFiles()
        {
            try
            {
                var imageFiles = await _imageFileService.GetAll();
                return Ok(imageFiles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los archivos de imágenes");
                return StatusCode(500); 
            }
        }

        [HttpGet("GetImageFileById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ImageFilesViewModel>> GetImageFileById(int id)
        {
            try
            {
                var imageFile = await _imageFileService.Find(id);
                if (imageFile == null)
                {
                    return NotFound();
                }
                return Ok(imageFile);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el archivo de imagen con ID: {id}");
                return StatusCode(500); 
            }
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


        [HttpPut("UpdateImage/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] ImageFilesViewModel imageFilesViewModel)
        {
            try
            {
                var existingImageFile = await _imageFileService.Find(id);
                if (existingImageFile == null)
                {
                    return NotFound();
                }

                await _imageFileService.Update(imageFilesViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el archivo de imagen con ID: {id}");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpDelete("DeleteImage/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                var existingImageFile = await _imageFileService.Find(id);
                if (existingImageFile == null)
                {
                    return NotFound();
                }

                await _imageFileService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el archivo de imagen con ID: {id}");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }
    }
}

