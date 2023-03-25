using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.ForBusService
{
    public interface IBusService
    {
        List<BusExpedition> busExpeditions { get; set; }
        Task GetAllBusExpedition();
    }
}
