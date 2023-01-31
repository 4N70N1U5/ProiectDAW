using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.UserDTOs;
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

        [HttpGet("get-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserGetDTO>>> GetAll()
        {
            return await _usersService.GetAllUsers();
        }

        [HttpGet("get-current"), Authorize]
        public async Task<ActionResult<UserGetDTO>> GetCurrent()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var currentUserId = _usersService.GetCurrentUserId(currentUserToken);

            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            return await _usersService.GetUserById(currentUserId);
        }

        [HttpGet("get-all-with-details"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserGetInfoDTO>>> GetInfoAll()
        {
            return await _usersService.GetInfoAllUsers();
        }

        [HttpGet("get-current-with-details"), Authorize]
        public async Task<ActionResult<UserGetInfoDTO>> GetInfoCurrent()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var currentUserId = _usersService.GetCurrentUserId(currentUserToken);

            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            return await _usersService.GetInfoUserById(currentUserId);
        }

        [HttpPut("make-customer"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> MakeCustomer(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.MakeCustomer(username, currentUserToken);

            if (response == Guid.Empty) return BadRequest("Something went wrong!");

            return Ok(await _usersService.GetUserById(response));
        }

        [HttpPut("make-admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> MakeAdmin(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.MakeAdmin(username, currentUserToken);

            if (response == Guid.Empty) return BadRequest("Something went wrong!");

            return Ok(await _usersService.GetUserById(response));
        }

        [HttpDelete("delete-user"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> Delete(string username)
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");

            if (currentUserToken == null) return BadRequest("Token is null!");

            var response = await _usersService.DeleteUser(username, currentUserToken);

            if (response == null) return BadRequest("Something went wrong!");

            return Ok(await _usersService.GetAllUsers());
        }
    }
}
