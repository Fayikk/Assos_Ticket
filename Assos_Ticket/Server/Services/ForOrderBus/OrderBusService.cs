using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assos_Ticket.Server.Services.ForOrderBus
{
    public class OrderBusService : IOrderBusService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        public OrderBusService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<OrderBus>> BusReservation(int id, int seatNo)
        {

            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            var expeditionBus = await _context.Busses.FirstOrDefaultAsync(x => x.BusId == id);
            var forSeatNumber = await _context.OrderBusses.Where(x => x.BusId == id).ToListAsync();
            var user = _authService.GetUserId();
            var userGender = await _context.Users.FirstOrDefaultAsync(x => x.Id == user);
            int coupleSeatNo = 0;
            foreach (var seat in forSeatNumber)
            {
                if (seat.SeatNo == seatNo)
                {
                    return new ServiceResponse<OrderBus>
                    {
                        Success = false,
                        Message = "Your seat is full,please choose other seats",
                    };
                }
            }
            if (expeditionBus.Capacitiy == 0)
            {
                return new ServiceResponse<OrderBus>
                {
                    Success = false,
                    Message = "All seats are full",
                };
            }


            if (seatNo % 2 == 0)
            {
                coupleSeatNo = seatNo - 1;
                var couple = await _context.OrderBusses.FirstOrDefaultAsync(x => x.SeatNo == coupleSeatNo);
                if (couple != null)
                {
                    if (couple.Gender != null && couple.Gender != userGender.Gender)
                    {
                        return new ServiceResponse<OrderBus>
                        {
                            Message = "You can share the same seat with your own gender as per the company's request.",
                            Success = false,
                        };
                    }
                }
            }
            else if (seatNo % 3 == 0)
            {
                coupleSeatNo = seatNo + 1;
                var couple = await _context.OrderBusses.FirstOrDefaultAsync(x => x.SeatNo == coupleSeatNo);

                if (couple != null)
                {
                    if (couple.Gender != userGender.Gender)
                    {
                        return new ServiceResponse<OrderBus>
                        {
                            Message = "You can share the same seat with your own gender as per the company's request.",
                            Success = false,
                        };
                    }
                }

            }
            for (int i = 0; i <= 9; i++)
            {
                sb.Append(random.Next(0, 9));
            }
            string conversationId = sb.ToString();
            OrderBus orderBus = new OrderBus();
            orderBus.SeatNo = seatNo;
            orderBus.BusId = id;
            orderBus.UserId = user;
            orderBus.Gender = userGender.Gender;
            orderBus.Price = expeditionBus.Price;
            orderBus.DateAndTime = expeditionBus.BeginingDate;
            orderBus.Rotate = expeditionBus.Begining + "-" + expeditionBus.Finish;
            orderBus.ConversationId = int.Parse(conversationId);
            expeditionBus.Capacitiy -= 1;
            _context.OrderBusses.Add(orderBus);
            _context.Busses.Update(expeditionBus);
            await _context.SaveChangesAsync();
            return new ServiceResponse<OrderBus>
            {
                Data = orderBus,
                Message = "Your Reservation is successfully please check your email",
                Success = true,
            };
        }

     

        public async Task<ServiceResponse<List<OrderBus>>> GetListByUser()
        {
            //Reservasyonlar listelenir
            var user = _authService.GetUserId();
            var result = await _context.OrderBusses.Where(x => x.UserId == user).ToListAsync();

            if (result == null)
            {
                return new ServiceResponse<List<OrderBus>>
                {
                    Message = "You dont have reservation",
                    Success = false,
                };
            }
            return new ServiceResponse<List<OrderBus>>
            {
                Data = result,
                Message = "",
                Success = true,
            };

        }

        public async Task<ServiceResponse<bool>> RefundReserve(int id)
        {
            //Listelenen rezervasyonlara onclick ile tetiklenerek bu metod'u sorgular; 
            DateTime time = new DateTime();
            var result = await _context.OrderBusses.FirstOrDefaultAsync(x => x.Id == id);
            var resultBus = await _context.Busses.FirstOrDefaultAsync(x => x.BusId == result.BusId);
            time = DateTime.UtcNow;
            if (time.Year<result.DateAndTime.Year && time.Month<result.DateAndTime.Month)
            {
                var refundTime = time.Hour - result.DateAndTime.Hour;
                if (refundTime >= 12)
                {
                    result.SeatNo = 0;
                    result.Status = false;
                    resultBus.Capacitiy += 1;
                    _context.OrderBusses.Update(result);
                    _context.Busses.Update(resultBus);
                    await _context.SaveChangesAsync();
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

