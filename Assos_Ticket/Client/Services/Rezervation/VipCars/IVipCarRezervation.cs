using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.Rezervation.VipCars
{
    public interface IVipCarRezervation
    {
        Task<ServiceResponse<string>> CreateRezervation(int id);
        Task GetMyRezerveList();
        List<RezerveVipCar> rezerveVipCars { get; set; }
    }
}
