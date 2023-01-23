using ProiectDAW.Models;
using ProiectDAW.Models.Enum;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Helpers.Utils;
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

        public UserResponseDTO Authenticate(string username, string password)
        {
            var user = _usersRepository.GetByUsername(username);

            if (user == null) return null;
            if (!BCryptNet.Verify(password, user.PasswordHash)) return null;

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, jwtToken);
        }

        public Guid GetCurrentUserId(string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            return currentUserId;
        }

        public async Task Register(User user)
        {
            await _usersRepository.CreateAsync(user);
            await _usersRepository.SaveAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.GetAllIncludeOrders();
            // return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<Guid> MakeCustomer(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return Guid.Empty;

            var userToEdit = _usersRepository.GetByUsername(username);

            if (userToEdit == null) return Guid.Empty;

            if (userToEdit.Id == currentUserId) return Guid.Empty;

            if (userToEdit.Role == Role.Customer) return Guid.Empty;

            userToEdit.Role = Role.Customer;
            userToEdit.DateModified = DateTime.UtcNow;

            await _usersRepository.SaveAsync();

            return userToEdit.Id;
        }

        public async Task<Guid> MakeAdmin(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return Guid.Empty;

            var userToEdit = _usersRepository.GetByUsername(username);

            if (userToEdit == null) return Guid.Empty;

            if (userToEdit.Id == currentUserId) return Guid.Empty;

            if (userToEdit.Role == Role.Admin) return Guid.Empty;

            userToEdit.Role = Role.Admin;
            userToEdit.DateModified = DateTime.UtcNow;

            await _usersRepository.SaveAsync();

            return userToEdit.Id;
        }

        public async Task<List<User>> DeleteUser(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return null;

            var userToDelete = _usersRepository.GetByUsername(username);

            if (userToDelete == null) return null;

            if (userToDelete.Id == currentUserId) return null;

            _usersRepository.Delete(userToDelete);

            await _usersRepository.SaveAsync();

            return await GetAllUsers();
        }
    }
}
