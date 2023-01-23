using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.Enum;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Services.UsersService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthenticationController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register-customer")]
        public async Task<ActionResult<User>> RegisterCustomer(UserRequestDTO request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCryptNet.HashPassword(request.Password),
                Role = Role.Customer,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _usersService.Register(newUser);

            return Ok(newUser);
        }

        [HttpPost("register-admin")]
        public async Task<ActionResult<User>> RegisterAdmin(UserRequestDTO request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCryptNet.HashPassword(request.Password),
                Role = Role.Admin,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _usersService.Register(newUser);

            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(string userName, string password)
        {
            var response = _usersService.Authenticate(userName, password);

            if (response == null) return BadRequest("Wrong username or password!");

            return Ok(response.Token);
        }
    }
}
