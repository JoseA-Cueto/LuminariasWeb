using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Services;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly IImageFileService _imageFileService;

        public ProductController(IProductService productService, ILogger logger, IImageFileService imageFileService) 
        {
            _productService = productService;
            _logger = logger;
            _imageFileService = imageFileService;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los productos");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el producto con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddProductWithImage([FromForm] ProductViewModel productViewModel, IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                {
                    return BadRequest("No se ha proporcionado ninguna imagen.");
                }

                // Leer los bytes del archivo de imagen
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    byte[] imgBytes = memoryStream.ToArray();

                    // Subir la imagen y obtener su información
                    var imageUploadResult = await _imageFileService.UploadImage(new ImageFilesViewModel
                    {
                        Name = imageFile.FileName,
                        Content = Convert.ToBase64String(imgBytes)
                    }, "DirectorioDeAlmacenamientoDeImagenes");

                    // Asignar la imagen al producto
                    productViewModel.ImagePath = imageUploadResult.Path;

                    // Agregar el producto con la imagen
                    await _productService.AddProductAsync(productViewModel);

                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo producto con imagen.");
                return StatusCode(500);
            }
        }


        [HttpPut("UpdateProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductViewModel productViewModel)
        {
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Si se proporciona una nueva imagen, actualiza la propiedad ImagePath
                if (!string.IsNullOrEmpty(productViewModel.ImagePath))
                {
                    existingProduct.ImagePath = productViewModel.ImagePath;
                }

                await _productService.UpdateProductAsync(productViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el producto con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el producto con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}



