using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Server.Services.ForPlane
{
    public interface IPlaneService
    {
        Task<ServiceResponse<PlaneExpeditionDTO>> CreatePlane(PlaneExpeditionDTO plane);
        Task<ServiceResponse<List<PlaneExpedition>>> GetFilterByPlane(FilterForPlane filter);
    }
}
