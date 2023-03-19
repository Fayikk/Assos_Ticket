using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
            OrderBus orderBus = new OrderBus();
            orderBus.SeatNo = seatNo;
            orderBus.BusId = id;
            orderBus.UserId = user;
            orderBus.Gender = userGender.Gender;
            orderBus.Price = expeditionBus.Price;
            orderBus.DateAndTime = expeditionBus.BeginingDate;
            orderBus.Rotate = expeditionBus.Begining + "-" + expeditionBus.Finish;
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
    }
}

