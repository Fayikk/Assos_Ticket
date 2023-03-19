using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForOrderBus
{
    public interface IOrderBusService
    {
        Task<ServiceResponse<OrderBus>> BusReservation(int id,int seatNo);
    }
}
