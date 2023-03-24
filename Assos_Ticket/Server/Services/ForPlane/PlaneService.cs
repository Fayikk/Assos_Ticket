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

        public async Task<ServiceResponse<PlaneExpedition>> DeletePlane(int planeId)
        {
            var result = await _dataContext.Planes.FirstOrDefaultAsync(x => x.PlaneId == planeId);
            if (result == null)
            {
                return new ServiceResponse<PlaneExpedition>
                {
                    Success = false,
                    Message = "Your process is failed",
                };
            }
            _dataContext.Planes.Remove(result);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<PlaneExpedition>
            {
                Success = true,
                Message = "Your process is success",
                Data = result,
            };
        }

        public async Task<ServiceResponse<List<PlaneExpedition>>> GetAllPlaneExpedition()
        {
            var result = await _dataContext.Planes.ToListAsync();
            if (result == null)
            {
                return new ServiceResponse<List<PlaneExpedition>>
                {
                    Message = "Your process is failed",
                    Success = false,
                };
            }
            return new ServiceResponse<List<PlaneExpedition>>
            {
                Data = result,
                Message = "Your process is success",
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
         ).OrderBy(x=>x.Price).ToListAsync();
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

        public async Task<ServiceResponse<PlaneExpeditionDTO>> GetPlaneById(int planeId)
        {
            var result = await _dataContext.Planes.FindAsync(planeId);
            if (result != null) 
            {
                return new ServiceResponse<PlaneExpeditionDTO>
                {
                    Success = false,
                    Message = "Your process is fail",
                };
            }
            var response = _mapper.Map<PlaneExpedition, PlaneExpeditionDTO>(result);

            return new ServiceResponse<PlaneExpeditionDTO>
            {
                Data = response,
                Message = "Your process is success",
                Success = true,
            };

        }

        public async Task<ServiceResponse<PlaneExpedition>> UpdatePlane(PlaneExpeditionDTO plane)
        {
            var result = await _dataContext.Planes.FirstOrDefaultAsync(x => x.PlaneId == plane.Id);
            var obj = _mapper.Map<PlaneExpedition, PlaneExpeditionDTO>(result);
            if (obj != null)
            {
                return new ServiceResponse<PlaneExpedition>
                {
                    Success = false,
                    Message = "Your process is failed",
                };
            }
            result.Capacity = plane.Capacity;
            result.ReturnBack = plane.ReturnBack;
            result.ReturnStatus = plane.ReturnStatus;
            result.Status = plane.Status;
            result.Begining = plane.Begining;
            result.BeginingDate= plane.BeginingDate;
            result.FinisingDate = plane.FinisingDate;
            result.CreatedDate = plane.CreatedDate;
            result.PlaneName = plane.PlaneName;
            result.Price = plane.Price;
            _dataContext.Planes.Update(result);
            await _dataContext.SaveChangesAsync();
            var reverseMap = _mapper.Map<PlaneExpeditionDTO, PlaneExpedition>(obj);
            return new ServiceResponse<PlaneExpedition>
            {
                Success = true,
                Message = "Your process is success",
                Data = reverseMap,
            };
        }
    }

}
