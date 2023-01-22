using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;

namespace ProiectDAW.Services.UsersService
{
    public interface IUsersService
    {
        UserResponseDTO Authenticate(string userName, string password);

        // Create
        Task Register(User user);

        // Read
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);

        // Update
        Task<List<User>> MakeAdmin(string userName);
    }
}
