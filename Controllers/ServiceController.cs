using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/Service")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly ILogger _logger; 

        public ServicesController(IServiceService serviceService, ILogger logger) 
        {
            _serviceService = serviceService;
            _logger = logger; 
        }

        [HttpGet("GetAllServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ServiceViewModel>>> GetAllServices()
        {
            try
            {
                var services = await _serviceService.GetServicesAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los servicios");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetServiceById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceViewModel>> GetServiceById(int id)
        {
            try
            {
                var service = await _serviceService.GetServiceByIdAsync(id);
                if (service == null)
                {
                    return NotFound();
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el servicio con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpPost("AddService")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddService([FromBody] ServiceViewModel serviceViewModel)
        {
            try
            {
                await _serviceService.AddServiceAsync(serviceViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo servicio");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceViewModel serviceViewModel)
        {
            try
            {
                var existingService = await _serviceService.GetServiceByIdAsync(id);
                if (existingService == null)
                {
                    return NotFound();
                }

                await _serviceService.UpdateServiceAsync(serviceViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el servicio con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var existingService = await _serviceService.GetServiceByIdAsync(id);
                if (existingService == null)
                {
                    return NotFound();
                }

                await _serviceService.DeleteServiceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el servicio con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}


