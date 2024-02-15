using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/ImageFile")]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageFileService _imageFileService;
        private readonly ILogger<ImageFileController> _logger;

        public ImageFileController(IImageFileService imageFileService, ILogger<ImageFileController> logger)
        {
            _imageFileService = imageFileService;
            _logger = logger;
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
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
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
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPost("UploadImage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadImage([FromForm] ImageFilesViewModel imageFilesViewModel, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Archivo no proporcionado o vacío");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    imageFilesViewModel.Content = Convert.ToBase64String(memoryStream.ToArray());
                }

                await _imageFileService.UploadImage(imageFilesViewModel, Directory.GetCurrentDirectory());
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al subir una nueva imagen");
                return StatusCode(500);
            }
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

