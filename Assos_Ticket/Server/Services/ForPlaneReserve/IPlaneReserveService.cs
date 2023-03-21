using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForPlaneReserve
{
    public interface IPlaneReserveService
    {
        Task<ServiceResponse<RezervePlane>> CreateRezerve(int planeId);
        Task<ServiceResponse<List<RezervePlane>>> ListMyRezerve();
    }
}
