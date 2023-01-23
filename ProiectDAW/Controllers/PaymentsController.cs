﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Services.PaymentsService;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost("create")]
        public async Task<ActionResult<Payment>> CreatePayment(PaymentDTO request)
        {
            var newPayment = new Payment()
            {
                CardIssuer = request.CardIssuer,
                CardNumber = request.CardNumber,
                CardType = request.CardType,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _paymentsService.CreatePayment(newPayment);

            return Ok(newPayment);
        }

        [HttpGet("get-all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Payment>>> GetAll()
        {
            return Ok(await _paymentsService.GetAllPayments());
        }

        [HttpPut("edit")]
        public async Task<ActionResult<Payment>> Edit(Guid id, PaymentDTO request)
        {
            var payment = new Payment()
            {
                CardIssuer = request.CardIssuer,
                CardNumber = request.CardNumber,
                CardType = request.CardType
            };

            var response = await _paymentsService.UpdatePayment(id, payment);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<List<Payment>>> Delete(Guid id)
        {
            var response = await _paymentsService.DeletePayment(id);

            if (response == null) return BadRequest("Invalid ID");

            return Ok(response);
        }
    }
}