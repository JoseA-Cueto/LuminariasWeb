using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.DataBaseInterface
{
    public interface IServiceRepository
    {
        Task<Service> GetServiceByIdAsync(int id);
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
