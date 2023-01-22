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
        public async Task<ActionResult<List<User>>> RegisterCustomer(UserRequestDTO request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCryptNet.HashPassword(request.Password),
                Role = Role.Customer
            };

            await _usersService.Register(newUser);

            return Ok(_usersService.GetUsers());
        }

        [HttpPost("register-admin")]
        public async Task<ActionResult<List<User>>> RegisterAdmin(UserRequestDTO request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCryptNet.HashPassword(request.Password),
                Role = Role.Admin
            };

            await _usersService.Register(newUser);

            return Ok(_usersService.GetUsers());
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserRequestDTO request)
        {
            var response = _usersService.Authenticate(request);

            if (response == null) return BadRequest("Wrong username or password!");

            return Ok(response.Token);
        }
    }
}
