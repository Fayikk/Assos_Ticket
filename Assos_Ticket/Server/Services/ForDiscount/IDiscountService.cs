using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForDiscount
{
    public interface IDiscountService
    {
        Task<ServiceResponse<bool>> DiscountBus(int id, int discount);
        Task<ServiceResponse<bool>> DiscountPlane(int id, int discount);
        Task<ServiceResponse<bool>> DiscountVipCar(int id, int discount);
    }
}
