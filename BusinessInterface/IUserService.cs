using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserViewModel userViewModel);
        Task UpdateUserAsync(UserViewModel userViewModel);
        Task DeleteUserAsync(int userId);
    }
}
