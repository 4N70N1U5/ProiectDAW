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

        [HttpGet("get-names-all")]
        public async Task<ActionResult<List<PublisherGetDTO>>> GetNames() 
        {
            return await _publishersService.GetPublishers();
        }

        [HttpPost("add-new"), Authorize(Roles = "Admin")]
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

        [HttpDelete("remove-publisher"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Publisher>>> Delete(Guid id)
        {
            var response = await _publishersService.DeletePublisher(id);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }
    }
}
