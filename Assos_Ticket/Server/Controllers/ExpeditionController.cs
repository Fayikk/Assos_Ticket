using Assos_Ticket.Server.Services.ForExpedition;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assos_Ticket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpeditionController : ControllerBase
    {
        private readonly IExpeditionService _expeditionService;
        public ExpeditionController(IExpeditionService expeditionService)
        {
            _expeditionService = expeditionService;
        }

    
    }
}
