using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.ForVipCarService
{
    public interface IVipCarService
    {
        List<VipCar> vipCars { get; set; }
        Task GetVipCars();
    }
}
