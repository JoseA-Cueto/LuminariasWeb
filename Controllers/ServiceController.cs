using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Controllers
{
    
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;

        public ServicesController(IServicesService servicesService, IMapper mapper)
        {
            _servicesService = servicesService;
            _mapper = mapper;
        }

        [HttpGet("GetAllServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            var services = await _servicesService.GetAllServicesAsync();
            if (services == null || services.Count == 0)
            {
                return NotFound();
            }
            return Ok(services);
        }

        [HttpGet("GetServiceById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var service = await _servicesService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost("AddService")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddService(ServiceViewModel serviceViewModel)
        {
            try
            {
                await _servicesService.AddServiceAsync(serviceViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateService(int id, ServiceViewModel serviceViewModel)
        {
            var existingService = await _servicesService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                await _servicesService.UpdateServiceAsync(serviceViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteService/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteService(int id)
        {
            var existingService = await _servicesService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                await _servicesService.DeleteServiceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}

