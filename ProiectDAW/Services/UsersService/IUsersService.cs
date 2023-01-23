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
        Task<Guid> MakeCustomer(string userName, string jwtToken);
        Task<Guid> MakeAdmin(string userName, string jwtToken);

        // Delete
        Task<List<User>> DeleteUser(string userName, string jwtToken);
    }
}
