using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;

namespace Assos_Ticket.Client.Services.ForVipCarService
{
    public interface IVipCarService
    {
        List<VipCar> vipCars { get; set; }
       //public VipCarDTO vipCar { get; set; } 
        Task GetVipCars();
        Task<VipCarDTO> GetVipCar(int id);
    }
}
