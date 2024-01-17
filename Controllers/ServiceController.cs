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

    [Route("api/Service")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("GetAllServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ServiceViewModel>>> GetAllServices()
        {
            var services = await _serviceService.GetServicesAsync();
            return Ok(services);
        }

        [HttpGet("GetServiceById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceViewModel>> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
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
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceViewModel serviceViewModel)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                await _serviceService.UpdateServiceAsync(serviceViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteService(int id)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                await _serviceService.DeleteServiceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }

}

