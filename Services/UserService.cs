using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
         public async Task<User> GetUserByIdAsync(int UserId)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(UserId);
                return _mapper.Map<User>(user);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw;
            }
        }
        private void HandleException(Exception ex)
        {
            Console.WriteLine($"Se produjo una excepción en ServicesService: {ex.Message}");

        }
    }
}
