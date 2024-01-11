using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminariasWeb.sln.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Set<User>().Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.Set<User>().FindAsync(id);
            if (user != null)
            {
                _dbContext.Set<User>().Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
