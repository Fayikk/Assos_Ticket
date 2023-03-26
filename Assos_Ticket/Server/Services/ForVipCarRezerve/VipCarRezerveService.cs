
using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared.Model;
using System.Text;
using Assos_Ticket.Server.Migrations;

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

            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
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
                if (result.CarStatus == true)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        sb.Append(random.Next(0, 9));
                    }
                    for (int i = 0; i <= 8; i++)
                    {
                        sb1.Append(random.Next(0, 8));
                    }
                    string conversationId = sb.ToString();
                    string paymentId = sb1.ToString();
                    RezerveVipCar vipCar = new RezerveVipCar();
                    vipCar.UserId = userId;
                    vipCar.Email = user.Email;
                    vipCar.TotalPrice = result.DailyPrice * totalDay;
                    vipCar.Deposit = result.Deposit;
                    vipCar.PickupPlace = result.PickupPlace;
                    vipCar.DropOfLocation = result.DropOfLocation;
                    vipCar.HowManyDays = totalDay;
                    vipCar.VipCarId = result.CarId;
                    vipCar.PaymentId = paymentId;
                    vipCar.ConversationId = conversationId;

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
                else
                {
                    return new ServiceResponse<RezerveVipCar> { Message = "This car is already take other customer sorry",Success = false };
                }
            }
            }

    
        public async Task<ServiceResponse<List<RezerveVipCar>>> ListMyRezerve()
        {
            var userId = _authService.GetUserId();
            var result = await _dataContext.RezerveVipCars.Where(x => x.UserId == userId).ToListAsync();
            if (result == null)
            {
                return new ServiceResponse<List<RezerveVipCar>>
                {
                    Message = "Your process is failed",
                    Success = false,

                };
            }
            return new ServiceResponse<List<RezerveVipCar>>
            {
                Data = result,
                Success = true,
                Message = "Process is success",
            };

        }

        public async Task<ServiceResponse<bool>> ToSubmitCar(int id)
        {
            var result = await _dataContext.RezerveVipCars.FirstOrDefaultAsync(x => x.RezerveVipCarId == id);
            var vipCar = await _dataContext.VipCars.FirstOrDefaultAsync(x => x.CarId == result.VipCarId);


            if (result != null)
            {
                if (vipCar != null)
                {
                    vipCar.CarStatus = true;
                    _dataContext.VipCars.Update(vipCar);
                    _dataContext.RezerveVipCars.Remove(result);
                   await _dataContext.SaveChangesAsync();
                    return new ServiceResponse<bool>
                    {
                        Success = true,
                    };
                }
            }
            return new ServiceResponse<bool>
            {
                Success = false,
            };
        }
    }

        
    }

