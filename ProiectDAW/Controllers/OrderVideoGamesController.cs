using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Services.OrdersService;
using ProiectDAW.Services.OrderVideoGamesService;
using ProiectDAW.Services.VideoGameService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderVideoGamesController : ControllerBase
    {
        private readonly IOrderVideoGamesService _orderVideoGamesService;
        private readonly IOrdersService _ordersService;
        private readonly IVideoGamesService _videoGamesService;

        public OrderVideoGamesController(IOrderVideoGamesService orderVideoGamesService, IOrdersService ordersService, IVideoGamesService videoGamesService)
        {
            _orderVideoGamesService = orderVideoGamesService;
            _ordersService = ordersService;
            _videoGamesService = videoGamesService;
        }

        [HttpPost("add-video-game-to-order"), Authorize]
        public async Task<IActionResult> AddVideoGameToOrder(Guid orderId, Guid videoGameId)
        {
            var order = await _ordersService.GetOrderById(orderId);
            if (order == null) { return BadRequest("Invalid Order ID!"); }

            var videoGame = await _videoGamesService.GetVideoGameById(videoGameId);
            if (videoGame == null) { return BadRequest("Invalid Video Game ID!"); }

            await _ordersService.UpdateOrderTotal(order, videoGame.Price);

            var newOrderVideoGame = new OrderVideoGame() { OrderId = orderId, VideoGameId = videoGameId };

            await _orderVideoGamesService.CreateOrderVideoGame(newOrderVideoGame);

            return Ok();
        }

        [HttpDelete("remove-video-game-from-order"), Authorize]
        public async Task<IActionResult> RemoveVideoGameFromOrder(Guid orderId, Guid videoGameId)
        {
            var order = await _ordersService.GetOrderById(orderId);
            if (order == null) { return BadRequest("Invalid Order ID!"); }

            var videoGame = await _videoGamesService.GetVideoGameById(videoGameId);
            if (videoGame == null) { return BadRequest("Invalid Video Game ID!"); }

            await _ordersService.UpdateOrderTotal(order, -1 * videoGame.Price);

            await _orderVideoGamesService.DeleteOrderVideoGame(orderId, videoGameId);

            return Ok();
        }
    }
}
