using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Server.Services.ForVipCar
{
    public interface IVipCarService
    {
        Task<ServiceResponse<VipCarDTO>> CreateVipCar(VipCarDTO vipCarDTO);
        Task<ServiceResponse<List<VipCar>>> GetAllVipCar();
        Task<ServiceResponse<VipCarDTO>> UpdateVipCar(VipCarDTO vipCarDTO);
        Task<ServiceResponse<bool>> DeleteVipCar(int id);
        Task<ServiceResponse<VipCarDTO>> GetByCar(int id);
        Task<ServiceResponse<List<VipCar>>> GetFilterByVipCar(FilterForVipCar filterForVipCar);
        Task<ServiceResponse<List<VipCar>>> SearchText(string searchText);  
    }
}
