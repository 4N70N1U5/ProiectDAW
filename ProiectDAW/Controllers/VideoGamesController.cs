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

        [HttpGet("get-all")]
        public async Task<ActionResult<List<VideoGameGetDTO>>> GetAll()
        {
            return Ok(await _videoGamesService.GetVideoGames());
        }

        [HttpGet("get-all-with-details")]
        public async Task<ActionResult<List<VideoGameGetInfoDTO>>> GetAllWithInfo()
        {
            return Ok(await _videoGamesService.GetVideoGamesWithInfo());
        }

        [HttpGet("get-all-with-copies-sold"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VideoGameCopiesDTO>>> GetAllWithCopiesSold()
        {
            return Ok(await _videoGamesService.GetVideoGamesWithCopiesSold());
        }

        [HttpPost("new-game"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VideoGameGetDTO>>> NewGame(VideoGameCreateDTO request)
        {
            var newVideoGame = new VideoGame()
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate.ToDateTime(TimeOnly.MinValue),
                Price = request.Price,
                PublisherId = request.PublisherId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _videoGamesService.CreateVideoGame(newVideoGame);

            return Ok(await _videoGamesService.GetVideoGames());
        }

        [HttpPut("edit-game"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditGame(Guid id, VideoGameEditDTO request)
        {
            var response = await _videoGamesService.UpdateVideoGame(id, request);

            if (response == null) return BadRequest("Invalid ID!");

            return Ok(response);
        }

        [HttpDelete("delete-game"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var response = await _videoGamesService.DeleteVideoGame(id);

            if (response == null) return BadRequest("Invalid ID!");

            return Ok(response);
        }
    }
}
