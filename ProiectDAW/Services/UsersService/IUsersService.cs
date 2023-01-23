using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;

namespace ProiectDAW.Services.UsersService
{
    public interface IUsersService
    {
        UserResponseDTO Authenticate(string userName, string password);

        Guid GetCurrentUserId(string jwtToken);

        // Create
        Task Register(User user);

        // Read
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);

        // Update
        Task<User> MakeAdmin(string userName);
    }
}
