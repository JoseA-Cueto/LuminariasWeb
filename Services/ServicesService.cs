using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IEnumerable<ServiceViewModel>> GetServicesAsync()
    {
        var services = await _serviceRepository.GetServicesAsync();
        return services.Select(s => new ServiceViewModel
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price,
            Description = s.Description
        });
    }

    public async Task<ServiceViewModel> GetServiceByIdAsync(int serviceId)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(serviceId);
        return service != null ? new ServiceViewModel
        {
            Id = service.Id,
            Name = service.Name,
            Price = service.Price,
            Description = service.Description
        } : null;
    }

    public async Task AddServiceAsync(ServiceViewModel serviceViewModel)
    {
        var service = new Service
        {
            Name = serviceViewModel.Name,
            Price = serviceViewModel.Price,
            Description = serviceViewModel.Description
        };
        await _serviceRepository.AddServiceAsync(service);
    }

    public async Task UpdateServiceAsync(ServiceViewModel serviceViewModel)
    {
        var existingService = await _serviceRepository.GetServiceByIdAsync(serviceViewModel.Id);
        if (existingService != null)
        {
            existingService.Name = serviceViewModel.Name;
            existingService.Price = serviceViewModel.Price;
            existingService.Description = serviceViewModel.Description;
            await _serviceRepository.UpdateServiceAsync(existingService);
        }
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        await _serviceRepository.DeleteServiceAsync(serviceId);
    }
}



