using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.DataBaseInterface
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service> GetServiceByIdAsync(int serviceId);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int serviceId);
    }
}
