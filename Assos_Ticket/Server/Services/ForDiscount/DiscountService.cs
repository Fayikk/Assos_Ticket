using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assos_Ticket.Server.Services.ForDiscount
{
    public class DiscountService : IDiscountService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        public DiscountService(DataContext context,IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<bool>> DiscountBus(int id, int discountTotal)
        {
            Discount discount = new Discount(); 
            var user = _authService.GetUserId();
            var forUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user);
            var expedition = await _context.Busses.FirstOrDefaultAsync(x=>x.BusId == id);
            discount.UserId = user;
            discount.BusId = id;
            discount.Status = true;
            discount.DiscountAmount=discountTotal;
            discount.Email = forUser.Email;
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Success = true,
                Message = "Your process is success,if this process is accept,we will information for you to this",
            };
        }
        public Task<ServiceResponse<bool>> DiscountPlane(int id, int discount)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DiscountVipCar(int id, int discount)
        {
            throw new NotImplementedException();
        }
    }
}
