using Assos_Ticket.Server.Services.ForVipCarRezerve;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VipCarRezerveController : ControllerBase
    {
        private readonly IVipCarRezerveService _vipCarRezerveService;
        public VipCarRezerveController(IVipCarRezerveService vipCarRezerveService)
        {
            _vipCarRezerveService= vipCarRezerveService;
        }

        [HttpPost,Authorize]
        public async Task<ActionResult<ServiceResponse<RezerveVipCar>>> CreateRezerveCar(int id)
        {
            var result = await _vipCarRezerveService.CreateVipCarRezerve(id);
            return Ok(result);
        }

        [HttpGet,Authorize]
        public async Task<ActionResult<ServiceResponse<List<RezerveVipCar>>>> GetMyList()
        {
            var result = await _vipCarRezerveService.ListMyRezerve();
            return Ok(result);
        }
        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<RezerveVipCar>>> SubmitCar(int id)
        {
            var result = await _vipCarRezerveService.ToSubmitCar(id);
            return Ok(result);
        }
    }
}
