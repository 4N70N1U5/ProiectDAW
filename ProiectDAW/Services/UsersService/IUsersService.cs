using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;

namespace ProiectDAW.Services.UsersService
{
    public interface IUsersService
    {
        UserResponseDTO Authenticate(string username, string password);

        Guid GetCurrentUserId(string jwtToken);

        // Create
        Task Register(User user);

        // Read
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);

        // Update
        Task<Guid> MakeCustomer(string username, string jwtToken);
        Task<Guid> MakeAdmin(string username, string jwtToken);

        // Delete
        Task<List<User>> DeleteUser(string username, string jwtToken);
    }
}
