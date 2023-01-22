using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Helpers.JwtUtils;
using ProiectDAW.Repositories.UsersRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectDAW.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtUtils _jwtUtils;

        public UsersService(IUsersRepository usersRepository, IJwtUtils jwtUtils)
        {
            _usersRepository = usersRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(string userName, string password)
        {
            var user = _usersRepository.GetByUserName(userName);

            if (user == null) return null;
            if (!BCryptNet.Verify(password, user.PasswordHash)) return null;

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, jwtToken);
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

        public Task<List<User>> MakeAdmin(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
