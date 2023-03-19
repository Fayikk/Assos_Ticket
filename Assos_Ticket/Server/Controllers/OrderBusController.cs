using Assos_Ticket.Server.Services.ForOrderBus;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<OrderBus>>>> GetByReserve()
        {
            var result = await _orderBusService.GetListByUser();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<bool>>> RefundReserve(int id)
        {
            var result = await _orderBusService.RefundReserve(id);
            return Ok(result);
        }

    }
}
