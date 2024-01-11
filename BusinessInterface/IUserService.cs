using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int UserId);
    }
}
