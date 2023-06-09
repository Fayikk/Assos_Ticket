﻿using Assos_Ticket.Server.PaymentSystem;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentConttroller : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentConttroller(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost,Authorize]
        public ActionResult<ServiceResponse<string>> Checkout(PaymentModel model)
        {
            var result = _paymentService.Should_Create_Payment(model);
            return Ok(result);
        }

        [HttpPut,Authorize]
        public IActionResult Refund()
        {
            var result = _paymentService.Cancel_Refund();
            return Ok(result);
        }

    }
}
