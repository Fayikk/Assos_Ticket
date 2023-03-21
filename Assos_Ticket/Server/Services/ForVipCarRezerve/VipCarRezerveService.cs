
using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Server.Services.ForVipCarRezerve
{
    public class VipCarRezerveService : IVipCarRezerveService
    {
        private readonly DataContext _dataContext;
        private IAuthService _authService;
        public VipCarRezerveService(IAuthService authService,DataContext dataContext)
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<ServiceResponse<RezerveVipCar>> CreateVipCarRezerve(int vipCarId)
        {
            var result = await _dataContext.VipCars.FirstOrDefaultAsync(x => x.CarId == vipCarId);
            var userId = _authService.GetUserId();
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var totalDay = result.DateOfReturn.Day - result.PurchaseDate.Day;
            if (result == null) {
                return new ServiceResponse<RezerveVipCar>
                {
                    Message = "This car is problem now sorry",
                    Success = false,
                };
            }
            else
            {
                RezerveVipCar vipCar = new RezerveVipCar();
                vipCar.UserId = userId;
                vipCar.Email = user.Email;
                vipCar.TotalPrice = result.DailyPrice * totalDay;
                vipCar.Deposit = result.Deposit;
                vipCar.PickupPlace = result.PickupPlace;
                vipCar.DropOfLocation = result.DropOfLocation;
                var addedObj = _dataContext.RezerveVipCars.Add(vipCar);
                if (addedObj.Entity != null)
                {
                    result.CarStatus = false;
                    _dataContext.VipCars.Update(result);
                }
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<RezerveVipCar>
                {
                    Message = "Your procces is success",
                    Data = vipCar,
                    Success = true,
                };
            }

        //public int RezerveVipCarId { get; set; }
        //[Required]
        //public int UserId { get; set; }
        //[Required]
        //public string Email { get; set; }
        //[Required]
        //public int HowManyDays { get; set; } //Gün aralığını bulup hesaplamayı ata
        //[Column(TypeName = "Decimal(18,2)")]
        //[Required]
        //public decimal? Deposit { get; set; }
        ////public string? CouponCode { get; set; }//-->Bunu yapalım
        //[Column(TypeName = "Decimal(18,2)")]
        //[Required]
        //public decimal? TotalPrice { get; set; }
        //public string? PickupPlace { get; set; }
        //public string? DropOfLocation { get; set; }

    }
    }
}
