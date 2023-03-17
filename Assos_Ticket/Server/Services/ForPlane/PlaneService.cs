using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Services.ForPlane
{
    public class PlaneService : IPlaneService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public PlaneService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PlaneExpeditionDTO>> CreatePlane(PlaneExpeditionDTO plane)
        {
            var obj = _mapper.Map<PlaneExpeditionDTO, PlaneExpedition>(plane);
            var addedObj = _dataContext.Planes.Add(obj);
            await _dataContext.SaveChangesAsync();
            var response = _mapper.Map<PlaneExpedition, PlaneExpeditionDTO>(addedObj.Entity);
            return new ServiceResponse<PlaneExpeditionDTO>
            {
                Data = response,
                Message = "Your process is successfully",
                Success = true,
            };
        }

        public async Task<ServiceResponse<List<PlaneExpedition>>> GetFilterByPlane(FilterForPlane filter)
        {



            if (filter.ReturnStatus == true)
            {
                var result = await _dataContext.Planes.Where(x => x.Begining.ToLower().Equals(filter.Begin.ToLower())
              && x.Finish.ToLower().Equals(filter.Finish.ToLower())
              && x.BeginingDate.Year == filter.BeginingDate.Year && x.BeginingDate.Month == filter.BeginingDate.Month && x.BeginingDate.Day == filter.BeginingDate.Day
              && x.FinisingDate.Year == filter.FinisingDate.Year && x.FinisingDate.Month == filter.FinisingDate.Month && x.FinisingDate.Day == filter.FinisingDate.Day
              && x.ReturnBack.Year == filter.ReturnBack.Year && x.ReturnBack.Month == filter.ReturnBack.Month && x.ReturnBack.Day == filter.ReturnBack.Day
              && x.ReturnStatus == filter.ReturnStatus
          ).OrderByDescending(x=>x.Price).ToListAsync();
                if (result.Count != 0)
                {
                    return new ServiceResponse<List<PlaneExpedition>>
                    {
                        Data = result,
                        Message = "Your process is successfully",
                        Success = true,
                    };
                }
                return new ServiceResponse<List<PlaneExpedition>>
                {
                    Message = "FAİL",
                    Success = false,
                };
            }
            else
            {
                var result = await _dataContext.Planes.Where(x => x.Begining.ToLower().Equals(filter.Begin.ToLower())
             && x.Finish.ToLower().Equals(filter.Finish.ToLower())
            && x.BeginingDate.Year == filter.BeginingDate.Year && x.BeginingDate.Month == filter.BeginingDate.Month && x.BeginingDate.Day == filter.BeginingDate.Day
              && x.FinisingDate.Year == filter.FinisingDate.Year && x.FinisingDate.Month == filter.FinisingDate.Month && x.FinisingDate.Day == filter.FinisingDate.Day
              && x.ReturnStatus == filter.ReturnStatus
         ).OrderByDescending(x=>x.Price).ToListAsync();
                if (result.Count != 0)
                {
                    return new ServiceResponse<List<PlaneExpedition>>
                    {
                        Data = result,
                        Message = "Your process is successfully",
                        Success = true,
                    };
                }
                return new ServiceResponse<List<PlaneExpedition>>
                {
                    Message = "FAİL",
                    Success = false,
                };
            }
        }


    }

}
