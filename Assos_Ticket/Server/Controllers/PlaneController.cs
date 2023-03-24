using Assos_Ticket.Server.Services.ForPlane;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        private readonly IPlaneService _planeService;
        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }


        [HttpPost("FilterByPlane")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<List<PlaneExpedition>>>> GetFilterByPlane([FromBody]FilterForPlane filter)
        {
            var result = await _planeService.GetFilterByPlane(filter);
            return Ok(result);
        }

        [HttpPost("CreatePlane")]
        //[Authorize(Roles ="Admin")]

        public async Task<ActionResult<ServiceResponse<PlaneExpedition>>> CreatePlane(PlaneExpeditionDTO planeExpedition)
        {
            var result = await _planeService.CreatePlane(planeExpedition);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PlaneExpedition>>> GetAll()
        {
            var result = await _planeService.GetAllPlaneExpedition();
            return Ok(result);
        }

        [HttpPut]
        //[Authorize]
        public async Task<ActionResult<ServiceResponse<PlaneExpeditionDTO>>> UpdateDTO(PlaneExpeditionDTO plane)
        {
            var result = await _planeService.UpdatePlane(plane);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<PlaneExpedition>>> DeletePlane(int planeId)
        {
            var result = await _planeService.DeletePlane(planeId);
            return Ok(result);
        }

    }
}
