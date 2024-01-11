using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.DataBaseInterface
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
    }
}
