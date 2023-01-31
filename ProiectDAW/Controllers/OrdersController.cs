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
        public async Task<ActionResult<List<OrderGetDTO>>> GetAllOrders()
        {
            return Ok(await _ordersService.GetOrders());
        }

        [HttpGet("get-all-with-details"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<OrderGetInfoDTO>>> GetAllOrdersWithDetails()
        {
            return Ok(await _ordersService.GetOrdersWithInfo());
        }

        [HttpGet("get-details/user/{username}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<OrderGetInfoPaymentDTO>>> GetAllOrdersWithDetailsUserId(string username)
        {
            return Ok(await _ordersService.GetOrdersWithInfoByUsername(username));
        }

        [HttpGet("get-details/current-user"), Authorize]
        public async Task<ActionResult<List<OrderGetInfoPaymentDTO>>> GetAllOrdersWithDetailsCurrentUser()
        {
            var currentUserToken = await HttpContext.GetTokenAsync("access_token");
            if (currentUserToken == null) return BadRequest("Token is null!");

            var currentUserId = _jwtUtils.ValidateJwtToken(currentUserToken);
            if (currentUserId == Guid.Empty) return BadRequest("JWT Token Validation failed!");

            return Ok(await _ordersService.GetOrdersWithInfoByUserId(currentUserId));
        }

        [HttpPost("new-order"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Order>> NewOrder(OrderCreateDTO request)
        {
            var newOrder = new Order()
            {
                PurchaseDate = request.PurchaseDate,
                OrderTotal = 0,
                UserId = request.UserId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _ordersService.CreateOrder(newOrder);

            return Ok(newOrder);
        }

        [HttpPost("new-order-current-user"), Authorize]
        public async Task<ActionResult<Order>> NewOrderCurrentUser()
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

        [HttpPut("edit-order"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Order>> EditOrder(Guid id, OrderEditDTO request)
        {
            var response = await _ordersService.UpdateOrder(id, request);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }

        [HttpDelete("delete-order"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Order>> DeleteOrder(Guid id)
        {
            var response = await _ordersService.DeleteOrder(id);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }
    }
}
