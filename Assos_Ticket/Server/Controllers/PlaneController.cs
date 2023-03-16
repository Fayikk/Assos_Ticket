﻿using Assos_Ticket.Server.Services.ForPlane;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ServiceResponse<List<PlaneExpedition>>>> GetFilterByPlane([FromBody]FilterForPlane filter)
        {
            var result = await _planeService.GetFilterByPlane(filter);
            return Ok(result);
        }

        [HttpPost("CreatePlane")]
        public async Task<ActionResult<ServiceResponse<PlaneExpedition>>> CreatePlane(PlaneExpeditionDTO planeExpedition)
        {
            var result = await _planeService.CreatePlane(planeExpedition);
            return Ok(result);
        }
    }
}
