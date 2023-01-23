using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Helpers.Utils;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.OrderDTOs;
using ProiectDAW.Services.OrdersService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IJwtUtils _jwtUtils;

        public OrdersController(IOrdersService ordersService, IJwtUtils jwtUtils)
        {
            _ordersService = ordersService;
            _jwtUtils = jwtUtils;
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            return await _ordersService.GetOrders();
        }

        [HttpPost("create"), Authorize]
        public async Task<ActionResult<Order>> CreateOrder()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");
            if (currentUserToken == null) return BadRequest("Token is null!");

            var currentUserId = _jwtUtils.ValidateJwtToken(currentUserToken);
            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            var newOrder = new Order()
            {
                PurchaseDate = DateTime.UtcNow,
                OrderTotal = 0,
                UserId = currentUserId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _ordersService.CreateOrder(newOrder);

            return Ok(newOrder);
        }
    }
}
