using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;

namespace Assos_Ticket.Server.Services.ForBus
{
    public interface IBusService
    {
        Task<ServiceResponse<BusExpeditionDTO>> CreateBus(BusExpeditionDTO bus);
        Task<ServiceResponse<BusExpedition>> DeleteBus(int busId);
        Task<ServiceResponse<BusExpedition>> UpdateBus(int busId,decimal price);
        Task<ServiceResponse<BusExpedition>> GetBus(int busId);
        Task<ServiceResponse<List<BusExpedition>>> GetAllBus();
        Task<ServiceResponse<List<BusExpedition>>> GetFilterByBus(string begining,string finishing,DateTime date);
     

    }
}
