using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared.Model;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> CreateRegister(UserRegister user)
        {
            var result = await _authService.Register(new User { Email = user.Email,Gender=user.Gender }, user.Password);
            return Ok(result);


        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginUser(UserLogin user)
        {
            var result = await _authService.Login(user.Email, user.Password);
            if (result == null)
            {
                return BadRequest("User is not found");
            }
            return Ok(result);
        }
        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            userId = int.Parse(user);
            var result = await _authService.ChangePassword(userId, oldPassword, newPassword, confirmPassword);

            if (result == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(result);
        }

        [HttpPost("role-admin"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> RoleAdmin(string email)
        {
            var result = await _authService.RoleForAdmin(email);
            if (result == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(result);
        }

        [HttpPost("DeleteAccount"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAccount(string password)
        {
            var result = await _authService.DeleteAccount(password);
            if (result == null)
            {
                return BadRequest("Something Went Wrong");
            }
            return Ok(result);
        }
    }
}
