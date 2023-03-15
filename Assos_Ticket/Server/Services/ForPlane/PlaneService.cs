using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Services.ForPlane
{
    public class PlaneService : IPlaneService
    {
        //private readonly DataContext _dataContext;
        //private readonly IMapper _mapper;
        //public PlaneService(DataContext dataContext,IMapper mapper)
        //{
        //    _dataContext = dataContext;
        //    _mapper = mapper;
        //}

        //public async Task<ServiceResponse<PlaneDTO>> CreatePlane(PlaneDTO plane)
        //{
        //    var obj = _mapper.Map<PlaneDTO, Plane>(plane);
        //    var addedObj = _dataContext.Planes.Add(obj);
        //    await _dataContext.SaveChangesAsync();
        //    var response = _mapper.Map<Plane, PlaneDTO>(addedObj.Entity);
        //    return new ServiceResponse<PlaneDTO>
        //    {
        //        Success = true,
        //        Message = "Your proccess is success",
        //        Data = response,
        //    };
        //}

        //public async Task<ServiceResponse<PlaneDTO>> DeletePlane(int planeId)
        //{
        //    var result = await _dataContext.Planes.FirstOrDefaultAsync(x=>x.Id== planeId);
        //    _dataContext.Planes.Remove(result);
        //    await _dataContext.SaveChangesAsync();
        //    var response = _mapper.Map<Plane, PlaneDTO>(result);
        //    return new ServiceResponse<PlaneDTO>
        //    {
        //        Data = response,
        //        Success = true,
        //        Message = "Your process is success",
        //    };

        //}

        //public async Task<ServiceResponse<List<Plane>>> GetAllPlane()
        //{
        //    var result = await _dataContext.Planes.ToListAsync();
        //    if (result == null)
        //    {
        //        return new ServiceResponse<List<Plane>>
        //        {
        //            Message = "Your proccess is not succes",
        //            Success = false
        //        };
        //    }
        //    return new ServiceResponse<List<Plane>>
        //    {
        //        Success = true,
        //        Data = result,
        //    };

        //}

        //public async Task<ServiceResponse<PlaneDTO>> GetPlane(int planeId)
        //{
        //    var result = await _dataContext.Planes.FindAsync(planeId);
        //    if (result == null)
        //    {
        //        return new ServiceResponse<PlaneDTO>
        //        {
        //            Success = false,
        //        };
        //    } 
        //    var response = _mapper.Map<Plane,PlaneDTO>(result);
        //    return new ServiceResponse<PlaneDTO>
        //    {
        //        Data = response,
        //        Success = true,
        //        Message = "PROCESS İS SUCCESSFULLY",
        //    };
        //}

        //public async Task<ServiceResponse<PlaneDTO>> UpdatePlane(PlaneDTO plane)
        //{
        //    var result = await _dataContext.Planes.FirstOrDefaultAsync(x => x.Id == plane.Id);
        //    if (result == null)
        //    {
        //        return new ServiceResponse<PlaneDTO>
        //        {
        //            Success = false,
        //        };
        //    } 
        //    var map = _mapper.Map<Plane, PlaneDTO>(result);
        //    result.BusName=map.BusName;
        //    result.SeatCount = map.SeatCount;
        //    result.Company = map.Company;
        //    _dataContext.Planes.Update(result);
        //    await _dataContext.SaveChangesAsync();
        //    var response = _mapper.Map<PlaneDTO, Plane>(map);

        //    return new ServiceResponse<PlaneDTO> {Message="Your process is success",Data=map };
        //}
    }
}
