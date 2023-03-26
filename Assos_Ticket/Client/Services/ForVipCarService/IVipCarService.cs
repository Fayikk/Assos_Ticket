using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Client.Services.ForVipCarService
{
    public interface IVipCarService
    {
        List<VipCar> vipCars { get; set; }
       //public VipCarDTO vipCar { get; set; } 
       List<FilterForVipCar> filterForVipCars { get; set; }
        Task GetVipCars();
        Task<VipCarDTO> GetVipCar(int id);

        Task<ServiceResponse<List<VipCar>>> FilterVipCars(FilterForVipCar vipCar);
    }
}
