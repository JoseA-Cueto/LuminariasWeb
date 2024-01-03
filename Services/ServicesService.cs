using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ServicesService : IServicesService
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public ServicesService(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Service>> GetAllServicesAsync()
    {
        try
        {
            var services = await _repository.GetAllServicesAsync();
            return _mapper.Map<List<Service>>(services);
        }
        catch (Exception ex)
        {
             HandleException(ex);
            throw;
        }
    }

    public async Task<Service> GetServiceByIdAsync(int serviceId)
    {
        try
        {
            var service = await _repository.GetServiceByIdAsync(serviceId);
            return _mapper.Map<Service>(service);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task AddServiceAsync(ServiceViewModel serviceViewModel)
    {
        try
        {
            var service = _mapper.Map<Service>(serviceViewModel);
            await _repository.AddServiceAsync(service);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task UpdateServiceAsync(ServiceViewModel serviceViewModel)
    {
        try
        {
            var updatedService = _mapper.Map<Service>(serviceViewModel);
            await _repository.UpdateServiceAsync(updatedService);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        try
        {
            await _repository.DeleteServiceAsync(serviceId);
        }
        catch (Exception ex)
        {
            HandleException(ex);
            throw;
        }
    }


    private void HandleException(Exception ex)
    {
        Console.WriteLine($"Se produjo una excepción: {ex.Message}");
       
    }
}

