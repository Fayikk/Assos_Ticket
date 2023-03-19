using Assos_Ticket.Server.Services.ForCarImage;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add-image")]
        [Authorize(Roles = "Admin")]

        public IActionResult CreateImage([FromForm] IFormFile file, [FromForm] int carId)
        {
            var result = _carImageService.Add(file, carId);
            if (result == null)
            {
                return BadRequest("Fail");
            }
            return Ok(result);
        }

        [HttpPost("add-image-plane")]
        [Authorize(Roles = "Admin")]

        public IActionResult CreateImagePlane([FromForm] IFormFile file, [FromForm] int planeId)
        {
            var result = _carImageService.AddPlane(file, planeId);
            if (result == null)
            {
                return BadRequest("Fail");
            }
            return Ok(result);
        }
        [HttpPost("add-image-bus")]
        [Authorize(Roles = "Admin")]

        public IActionResult CreateImageBus([FromForm] IFormFile file, [FromForm] int busId)
        {
            var result = _carImageService.AddBus(file, busId);
            if (result == null)
            {
                return BadRequest("Fail");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageByCar(int id)
        {
            var response = await _carImageService.GetImageByGuid(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }


            var imageBytes = new byte[0];
         

            string mimeType;
            if (response.Data.Name.EndsWith(".jpeg") || response.Data.Name.EndsWith(".jpg"))
            {
                mimeType = "image/jpeg";
            }
            else if (response.Data.Name.EndsWith(".png"))
            {
                mimeType = "image/png";
            }
            else if (response.Data.Name.EndsWith(".gif"))
            {
                mimeType = "image/gif";
            }
            else
            {
                mimeType = "application/octet-stream";
            }

            return File(imageBytes, mimeType);
        }


        [HttpGet]
        public List<CarImage> Get()
        {
            return _carImageService.GetAll();
        }
    }
}
