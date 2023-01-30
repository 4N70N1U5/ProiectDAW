using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;
using ProiectDAW.Services.VideoGameService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGamesService _videoGamesService;

        public VideoGamesController(IVideoGamesService videoGamesService)
        {
            _videoGamesService = videoGamesService;
        }

        [HttpGet("get-all-games")]
        public async Task<ActionResult<List<VideoGameGetDTO>>> GetAllGames()
        {
            return Ok(_videoGamesService.GetVideoGames());
        }

        [HttpPost("add-new-game"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VideoGameGetDTO>>> AddNewGame(VideoGameCreateDTO request)
        {
            var newVideoGame = new VideoGame()
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                Price = request.Price,
                PublisherId = request.PublisherId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _videoGamesService.CreateVideoGame(newVideoGame);

            return Ok(_videoGamesService.GetVideoGames());
        }


    }
}
