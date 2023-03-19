using Assos_Ticket.Server.Services.ForDiscount;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("discount-bus")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> CreateDiscountBus(int expedition,int discount)
        {
            var result = await _discountService.DiscountBus(expedition, discount);
            return Ok(result);  
        }
    }
}
