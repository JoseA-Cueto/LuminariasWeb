using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DbContext _dbContext;

        public ServiceRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _dbContext.Set<Service>().FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _dbContext.Set<Service>().ToListAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            await _dbContext.Set<Service>().AddAsync(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _dbContext.Set<Service>().Update(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _dbContext.Set<Service>().FindAsync(id);
            if (service != null)
            {
                _dbContext.Set<Service>().Remove(service);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
