using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;

namespace ProiectDAW.Services.UsersService
{
    public interface IUsersService
    {
        UserResponseDTO Authenticate(UserRequestDTO request);

        // Create
        Task Register(User user);

        // Read
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
    }
}
