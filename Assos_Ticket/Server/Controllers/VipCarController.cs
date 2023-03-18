using Assos_Ticket.Server.Services.ForVipCar;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VipCarController : ControllerBase
    {
        private readonly IVipCarService _vipCarService;
        public VipCarController(IVipCarService vipCarService)
        {
            _vipCarService = vipCarService;
        }


        [HttpPost("forFilter")]
        public async Task<ActionResult<ServiceResponse<List<VipCar>>>> FilterByCar(FilterForVipCar car,bool status)
        {
            var result = await _vipCarService.GetFilterByVipCar(car, status);
            return Ok(result);  
        }
        [HttpPost("Create")]
        public async Task<ActionResult<ServiceResponse<VipCarDTO>>> CreateCar(VipCarDTO car)
        {
            var result = await _vipCarService.CreateVipCar(car);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<VipCarDTO>>> GetCarById([FromRoute]int id)
        {
            var result = await _vipCarService.GetByCar(id);
            return Ok(result);
        }
    }
}
