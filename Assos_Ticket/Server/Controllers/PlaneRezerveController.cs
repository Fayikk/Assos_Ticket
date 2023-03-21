using Assos_Ticket.Server.Services.ForPlaneReserve;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneRezerveController : ControllerBase
    {
        private readonly IPlaneReserveService _planeRezerveService;
        public PlaneRezerveController(IPlaneReserveService planeReserveService)
        {
            _planeRezerveService = planeReserveService;
        }

        [HttpPost("Rezerve-Plane")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<RezervePlane>>> CreateRezervePlane(int id)
        {
            var result = await _planeRezerveService.CreateRezerve(id);
            return Ok(result);  

        }

        [HttpGet("List-Rezerve")]
        public async Task<ActionResult<ServiceResponse<List<RezervePlane>>>> GetAllMyReserve()
        {
            var result = await _planeRezerveService.ListMyRezerve();
            return Ok(result);
        }
    }
}
