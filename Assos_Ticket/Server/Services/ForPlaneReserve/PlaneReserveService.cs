using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto.Signers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Assos_Ticket.Server.Services.ForPlaneReserve
{
    public class PlaneReserveService : IPlaneReserveService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        public PlaneReserveService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<RezervePlane>> CreateRezerve(int planeId)
        {

            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();

            var userId = _authService.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var result = await _context.Planes.FirstOrDefaultAsync(x => x.PlaneId == planeId);
            string forTime = "";


            if (result.BeginingDate.Day == result.FinisingDate.Day)
            {
                var forHour = (result.FinisingDate.Hour - result.BeginingDate.Hour).ToString();
                var forMinute = (result.FinisingDate.Minute - result.BeginingDate.Minute).ToString();
                forTime = forHour + "-" + forMinute;
            }
            else
            {
                var forHour = (result.FinisingDate.Hour + (24 - result.BeginingDate.Hour).ToString());
                var forMinute = (result.FinisingDate.Minute + result.BeginingDate.Minute).ToString();
                forTime = forHour + "-" + forMinute;

            }


            if (result == null)
            {
                return new ServiceResponse<RezervePlane>
                {
                    Message = "Your choose expedition not found,please check again",
                    Success = false,
                };
            }
            if (result.Capacity == 0)
            {
                return new ServiceResponse<RezervePlane>
                {
                    Message = "This expedition is not any has seat",
                    Success = false,
                };
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    sb.Append(random.Next(0, 9));
                }//
            }
            for (int i = 0; i <= 8; i++)
            {
                sb1.Append(random.Next(0, 8));
            }
            string conversationId = sb.ToString();
            string paymentId = sb1.ToString();
            RezervePlane plane = new RezervePlane();
            plane.DepartureDate = result.BeginingDate;
            plane.Price = result.Price;
            plane.Company = result.Company;
            plane.TravelTime = forTime;
            plane.Email = user.Email;
            plane.UserId = user.Id;
            plane.PaymentId = paymentId;
            plane.ConversationId = conversationId;

            if (plane.Luggage > 15)
            {
                var amount = plane.Luggage - 15;
                plane.Price = plane.Price + Convert.ToDecimal(amount * 5);
            }
            result.Capacity -= 1;

            _context.RezervePlanes.Add(plane);
            _context.Planes.Update(result);
            await _context.SaveChangesAsync();
            return new ServiceResponse<RezervePlane>
            {
                Data = plane,
                Message = "Successfully",
                Success = true,
            };
        }

        public async Task<ServiceResponse<List<RezervePlane>>> ListMyRezerve()
        {
            var userId = _authService.GetUserId();
            var forUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var getRezerve = await _context.RezervePlanes.Where(x => x.UserId == userId).ToListAsync();
            if (getRezerve == null)
            {
                return new ServiceResponse<List<RezervePlane>>
                {
                    Message = "You dont have rezervation",
                    Success = true,
                };
            }
            return new ServiceResponse<List<RezervePlane>> { Data = getRezerve, Success = true, Message = "Successfully" };
        }
    }


}

