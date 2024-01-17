using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password
                // Agrega otras propiedades según sea necesario
            });
        }

        public async Task<UserViewModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user != null ? new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
                // Agrega otras propiedades según sea necesario
            } : null;
        }

        public async Task AddUserAsync(UserViewModel userViewModel)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                Password = userViewModel.Password
                // Agrega otras propiedades según sea necesario
            };
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserViewModel userViewModel)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userViewModel.Id);
            if (existingUser != null)
            {
                existingUser.Name = userViewModel.Name;
                existingUser.Password = userViewModel.Password;
                // Actualiza otras propiedades según sea necesario
                await _userRepository.UpdateUserAsync(existingUser);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
