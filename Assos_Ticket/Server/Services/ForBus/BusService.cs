using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assos_Ticket.Server.Services.ForBus
{
    public class BusService : IBusService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public BusService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BusExpeditionDTO>> CreateBus(BusExpeditionDTO bus)
        {
            var obj = _mapper.Map<BusExpeditionDTO, BusExpedition>(bus);
            var addedObj = _dataContext.Busses.Add(obj);
            await _dataContext.SaveChangesAsync();
            var response = _mapper.Map<BusExpedition, BusExpeditionDTO>(addedObj.Entity);
            return new ServiceResponse<BusExpeditionDTO>
            {
                Data = response,
                Message = "Success",
                Success = true,
            };

        }

        public async Task<ServiceResponse<BusExpedition>> DeleteBus(int busId)
        {
            var result = await _dataContext.Busses.FirstOrDefaultAsync(x => x.BusId == busId);
            if (result != null)
            {
                return new ServiceResponse<BusExpedition>
                {
                    Message = "Failed",
                    Success = false,
                };
            }
            _dataContext.Busses.Remove(result);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<BusExpedition>
            {
                Data = result,
                Message = "Success",
                Success = true,
            };
        }

        public async Task<ServiceResponse<List<BusExpedition>>> GetAllBus()
        {
            var result = await _dataContext.Busses.ToListAsync();
            if (result == null)
            {
                return new ServiceResponse<List<BusExpedition>>
                {
                    Success = false,
                    Message = "Item is not found"
                };
            }
            return new ServiceResponse<List<BusExpedition>>
            {
                Data = result,
                Message = "Success",
                Success = true,
            };
        }

        public async Task<ServiceResponse<BusExpedition>> GetBus(int busId)
        {
            var result = await _dataContext.Busses.FindAsync(busId);
            var forImage = await _dataContext.CarImages.FirstOrDefaultAsync(x => x.BusId == busId);
            if (result == null)
            {
                return new ServiceResponse<BusExpedition>
                {
                    Success = false,
                    Message = "Failed",
                };
            }
            result.ImageUrl = forImage.ImageUrl;
            return new ServiceResponse<BusExpedition>
            {
                Data = result,
                Message = "Success",
                Success = true,
            };

        }

        public async Task<ServiceResponse<List<BusExpedition>>> GetFilterByBus(string begining, string finishing, DateTime date)
        {
            var result = await _dataContext.Busses
                    .Where(x => x.Begining.ToLower().Equals(finishing.ToLower())
                    && x.Finish.ToLower().Equals(finishing.ToLower())
                    && x.BeginingDate.Year == date.Year
                     && x.BeginingDate.Month == date.Month
                      && x.BeginingDate.Day == date.Day).ToListAsync();

            if (result == null)
            {
                return new ServiceResponse<List<BusExpedition>>
                {
                    Success = false,
                    Message = "Your search criteria expedition is not found",
                };
            }
            return new ServiceResponse<List<BusExpedition>>
            {
                Data = result,
                Message = "Successfull",
                Success = true,
            };

        }

        public async Task<ServiceResponse<BusExpedition>> UpdateBus(BusExpedition bus)
        {
            var result = await _dataContext.Busses.FirstOrDefaultAsync(x => x.BusId == bus.BusId);
            if (result == null)
            {
                return new ServiceResponse<BusExpedition>
                {
                    Success = false,
                };
            }
            return new ServiceResponse<BusExpedition>
            {
                Data = result,
                Message = "Success",
                Success = true,
            };

        }
    }
}
