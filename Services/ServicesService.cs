using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
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
        var services = await _repository.GetAllServicesAsync();
        return _mapper.Map<List<Service>>(services);
    }

    public async Task<Service> GetServiceByIdAsync(int serviceId)
    {
        var service = await _repository.GetServiceByIdAsync(serviceId);
        return _mapper.Map<Service>(service);
    }

    public async Task AddServiceAsync(ServiceViewModel serviceViewModel)
    {
        var service = _mapper.Map<Service>(serviceViewModel);
        await _repository.AddServiceAsync(service);
    }

    public async Task UpdateServiceAsync(ServiceViewModel serviceViewModel)
    {
        var updatedService = _mapper.Map<Service>(serviceViewModel);
        await _repository.UpdateServiceAsync(updatedService);
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        await _repository.DeleteServiceAsync(serviceId);
    }
}
