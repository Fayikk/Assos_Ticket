using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Services.ForBus
{
    public class BusService : IBusService
    {
        //private readonly DataContext _dataContext;
        //private readonly IMapper _mapper;
        //public BusService(DataContext dataContext, IMapper mapper)
        //{
        //    _dataContext = dataContext;
        //    _mapper = mapper;
        //}

        //public async Task<ServiceResponse<BusDTO>> CreateBus(BusDTO bus)
        //{
        //    var obj = _mapper.Map<BusDTO, Bus>(bus);
        //    var addedObj = _dataContext.Busses.Add(obj);
        //    await _dataContext.SaveChangesAsync();
        //    var response = _mapper.Map<Bus, BusDTO>(addedObj.Entity);
        //    return new ServiceResponse<BusDTO>
        //    {
        //        Data = response,
        //        Message = "You proccess is succes",
        //        Success = true,
        //    };
        //}

        //public async Task<ServiceResponse<Bus>> DeleteBus(int busId)
        //{
        //    var result = await _dataContext.Busses.FirstOrDefaultAsync(x => x.Id == busId);
        //    ServiceResponse<Bus> serviceResponse = new ServiceResponse<Bus>();
        //    if (result.Id == null)
        //    {
        //        serviceResponse.Success = false;
        //        serviceResponse.Message = "This id is not found";
        //    };
        //    _dataContext.Busses.Remove(result);
        //    await _dataContext.SaveChangesAsync();
        //    return new ServiceResponse<Bus>
        //    {
        //        Message = "Your proccess is success",
        //        Success = true,
        //        Data = result,
        //    };



        //}

        //public async Task<ServiceResponse<List<Bus>>> GetAllBus()
        //{
        //    var result = await _dataContext.Busses.ToListAsync();
        //    return new ServiceResponse<List<Bus>>
        //    {
        //        Data = result,
        //        Message = "Your process is success",
        //        Success = true,
        //    };

        //}

        //public async Task<ServiceResponse<Bus>> GetBus(int busId)
        //{
        //    var result = await _dataContext.Busses.FirstOrDefaultAsync(x => x.Id == busId);
        //    if (result == null)
        //    {
        //        return new ServiceResponse<Bus>
        //        {
        //            Message = "Process is not success",
        //            Success = false,
        //        };
        //    }
        //    return new ServiceResponse<Bus>
        //    {
        //        Data = result,
        //        Message = "Process is success",
        //        Success = false,
        //    };
        //}

        //public async Task<ServiceResponse<Bus>> UpdateBus(Bus bus)
        //{
        //    var result = await _dataContext.Busses.FirstOrDefaultAsync(x => x.Id == bus.Id);
        //    if (result == null)
        //    {
        //        return new ServiceResponse<Bus>
        //        {
        //            Success = false,
        //            Data = result,
        //            Message = "Your process is not success",
        //        };
        //    }
        //    result.BusName = bus.BusName;
        //    result.SeatCount = bus.SeatCount;
        //    result.Company = bus.Company;
        //    _dataContext.Busses.Update(result);
        //    await _dataContext.SaveChangesAsync();
        //    return new ServiceResponse<Bus>
        //    {
        //        Data = result,
        //        Message = "Your proccess is success",
        //        Success = false,
        //    };

        //}
    }
}
