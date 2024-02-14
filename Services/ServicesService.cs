using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LuminariasWeb.sln.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceViewModel>> GetServicesAsync()
        {
            var services = await _serviceRepository.GetServicesAsync();
            return _mapper.Map<IEnumerable<ServiceViewModel>>(services);
        }

        public async Task<ServiceViewModel> GetServiceByIdAsync(int serviceId)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(serviceId);
            return _mapper.Map<ServiceViewModel>(service);
        }

        public async Task AddServiceAsync(ServiceViewModel serviceViewModel)
        {
            var service = _mapper.Map<Service>(serviceViewModel);
            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateServiceAsync(ServiceViewModel serviceViewModel)
        {
            var existingService = await _serviceRepository.GetServiceByIdAsync(serviceViewModel.Id);
            if (existingService != null)
            {
                _mapper.Map(serviceViewModel, existingService);
                await _serviceRepository.UpdateServiceAsync(existingService);
            }
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            await _serviceRepository.DeleteServiceAsync(serviceId);
        }
    }
}




