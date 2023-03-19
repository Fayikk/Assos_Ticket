using Assos_Ticket.Server.Services.ForOrderBus;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBusController : ControllerBase
    {
        private readonly IOrderBusService _orderBusService;
        public OrderBusController(IOrderBusService orderBusService)
        {
            _orderBusService = orderBusService;
        }

        [HttpPost("Create-Reservation")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<OrderBus>>> CreateReserve(int id, int seatNo)
        {
            var result = await _orderBusService.BusReservation(id, seatNo);
            return Ok(result);
        }

    }
}
