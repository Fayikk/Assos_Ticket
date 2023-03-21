using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForPlaneReserve
{
    public interface IPlaneReserveService
    {
        Task<ServiceResponse<RezervePlane>> CreateRezerve(RezervePlane plane);
        Task<ServiceResponse<List<RezervePlane>>> ListMyRezerve();
    }
}
