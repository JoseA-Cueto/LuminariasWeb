
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IServicesService
    {
        Task<List<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int serviceId);
        Task AddServiceAsync(ServiceViewModel serviceViewModel);
        Task UpdateServiceAsync(ServiceViewModel serviceViewModel);
        Task DeleteServiceAsync(int serviceId);
    }
}