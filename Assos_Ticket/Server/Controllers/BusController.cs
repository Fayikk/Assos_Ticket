using Assos_Ticket.Server.Services.ForBus;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<BusExpeditionDTO>>> CreateBus(BusExpeditionDTO busDTO)
        {
            var result = await _busService.CreateBus(busDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Expedition>>>> GetBusExpeditionFilter(string begin, string finish, DateTime date)
        {
            var result = await _busService.GetFilterByBus(begin, finish, date);
            if (result == null)
            {
                return BadRequest("Fail");
            }
            return Ok(result);
        }
    }
}
