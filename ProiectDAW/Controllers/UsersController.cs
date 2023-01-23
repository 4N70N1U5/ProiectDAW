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

        [HttpGet("display-info-all-users"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> DisplayAllUsers()
        {
            return await _usersService.GetAllUsers();
        }

        [HttpGet("display-info-current-user"), Authorize]
        public async Task<ActionResult<User>> DisplayCurrentUser()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            var currentUserId = _usersService.GetCurrentUserId(currentUserToken);

            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            return await _usersService.GetUserById(currentUserId);
        }

        //[HttpPut("make-user-admin"), Authorize(Roles = "Admin")]
        //public async Task<ActionResult<User>> MakeUserAdmin(string userName)
        //{

        //}
    }
}
