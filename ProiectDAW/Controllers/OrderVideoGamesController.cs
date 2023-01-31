using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Services.OrderVideoGamesService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderVideoGamesController : ControllerBase
    {
        private readonly IOrderVideoGamesService _orderVideoGamesService;

        public OrderVideoGamesController(IOrderVideoGamesService orderVideoGamesService)
        {
            _orderVideoGamesService = orderVideoGamesService;
        }

        [HttpPost("add-video-game-to-order"), Authorize]
        public async Task<ActionResult<OrderVideoGame>> AddVideoGameToOrder(Guid orderId, Guid videoGameId)
        {
            var newOrderVideoGame = new OrderVideoGame() { OrderId = orderId, VideoGameId = videoGameId };

            await _orderVideoGamesService.CreateOrderVideoGame(newOrderVideoGame);

            return Ok(newOrderVideoGame);
        }

        [HttpDelete("remove-video-game-from-order"), Authorize]
        public async Task<ActionResult<List<OrderVideoGame>>> RemoveVideoGameFromOrder(Guid orderId, Guid videoGameId)
        {
            return await _orderVideoGamesService.DeleteOrderVideoGame(orderId, videoGameId);
        }
    }
}
