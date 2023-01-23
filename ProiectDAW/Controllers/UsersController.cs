using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Services.UsersService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("get-info-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _usersService.GetAllUsers();
        }

        [HttpGet("get-info-current"), Authorize]
        public async Task<ActionResult<User>> GetCurrent()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var currentUserId = _usersService.GetCurrentUserId(currentUserToken);

            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            return await _usersService.GetUserById(currentUserId);
        }

        [HttpPut("make-customer"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> MakeCustomer(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.MakeCustomer(username, currentUserToken);

            if (response == Guid.Empty) return BadRequest("Something went wrong!");

            return Ok("User is now a customer.");
        }

        [HttpPut("make-admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> MakeAdmin(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.MakeAdmin(username, currentUserToken);

            if (response == Guid.Empty) return BadRequest("Something went wrong!");

            return Ok("User is now an admin.");
        }

        [HttpDelete("delete"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.DeleteUser(username, currentUserToken);

            if (response == null) return BadRequest("Something went wrong!");

            return Ok("User deleted");
        }
    }
}
