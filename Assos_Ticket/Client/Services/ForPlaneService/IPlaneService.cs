using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.ForPlaneService
{
    public interface IPlaneService
    {
        List<PlaneExpedition> planeExpeditions { get; set; }
        Task GetPlaneList();
    }
}
