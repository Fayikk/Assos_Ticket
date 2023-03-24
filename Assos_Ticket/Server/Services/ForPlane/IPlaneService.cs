using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;
using System.Numerics;

namespace Assos_Ticket.Server.Services.ForPlane
{
    public interface IPlaneService
    {
        Task<ServiceResponse<PlaneExpeditionDTO>> CreatePlane(PlaneExpeditionDTO plane);
        Task<ServiceResponse<List<PlaneExpedition>>> GetFilterByPlane(FilterForPlane filter);
        Task<ServiceResponse<PlaneExpeditionDTO>> GetPlaneById(int planeId);
        Task<ServiceResponse<PlaneExpedition>> UpdatePlane(PlaneExpeditionDTO plane);
        Task<ServiceResponse<PlaneExpedition>> DeletePlane(int planeId);

        Task<ServiceResponse<List<PlaneExpedition>>> GetAllPlaneExpedition();

    }
}
