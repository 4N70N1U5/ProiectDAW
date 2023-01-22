using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Repositories.UsersRepository;

namespace ProiectDAW.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public UserResponseDTO Authenticate(UserRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task Register(User user)
        {
            await _usersRepository.CreateAsync(user);
            await _usersRepository.SaveAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }
    }
}
