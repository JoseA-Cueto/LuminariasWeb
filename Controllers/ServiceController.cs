using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Controllers
{
    [ApiController]
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            var services = await _servicesService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var service = await _servicesService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult> AddService(ServiceViewModel serviceViewModel)
        {
            await _servicesService.AddServiceAsync(serviceViewModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, ServiceViewModel serviceViewModel)
        {
            var existingService = await _servicesService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }
            await _servicesService.UpdateServiceAsync(serviceViewModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var existingService = await _servicesService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound();
            }
            await _servicesService.DeleteServiceAsync(id);
            return Ok();
        }
    }
}

