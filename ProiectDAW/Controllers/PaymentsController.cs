using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Services.PaymentsService;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<PaymentGetDTO>>> GetAll()
        {
            return Ok(await _paymentsService.GetPayments());
        }

        [HttpGet("get-all-with-details"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<PaymentGetDTO>>> GetAllWithDetails()
        {
            return Ok(await _paymentsService.GetPaymentsWithInfo());
        }

        [HttpPost("new-payment"), Authorize]
        public async Task<ActionResult<Payment>> CreatePayment(PaymentCreateDTO request)
        {
            var newPayment = new Payment()
            {
                CardIssuer = request.CardIssuer,
                CardNumber = request.CardNumber,
                CardType = request.CardType,
                OrderId = request.OrderId,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _paymentsService.CreatePayment(newPayment);

            return Ok(newPayment);
        }

        [HttpPut("edit-payment"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Payment>> Edit(Guid id, PaymentEditDTO request)
        {
            var response = await _paymentsService.UpdatePayment(id, request);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }

        [HttpDelete("delete-payment"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Payment>>> Delete(Guid id)
        {
            var response = await _paymentsService.DeletePayment(id);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }
    }
}
