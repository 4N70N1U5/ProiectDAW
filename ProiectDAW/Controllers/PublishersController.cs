using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PublisherDTOs;
using ProiectDAW.Services.PublishersService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<PublisherGetDTO>>> GetAll() 
        {
            return await _publishersService.GetPublishers();
        }

        [HttpGet("get-all-with-details")]
        public async Task<ActionResult<List<PublisherGetInfoDTO>>> GetAllWithDetails()
        {
            return await _publishersService.GetPublishersWithInfo();
        }

        [HttpPost("new-publisher"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publisher>> Add(PublisherCreateEditDTO request)
        {
            var newPublisher = new Publisher()
            {
                Name = request.Name,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _publishersService.CreatePublisher(newPublisher);

            return newPublisher;
        }

        [HttpPut("edit-publisher"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publisher>> Edit(Guid id, PublisherCreateEditDTO request)
        {
            var response = await _publishersService.UpdatePublisher(id, request);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }

        [HttpDelete("delete-publisher"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Publisher>>> Delete(Guid id)
        {
            var response = await _publishersService.DeletePublisher(id);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }
    }
}
