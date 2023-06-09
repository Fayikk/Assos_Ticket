﻿using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
//using static System.Net.Mime.MediaTypeNames;

namespace Assos_Ticket.Server.Services.ForVipCar
{
    public class VipCarService : IVipCarService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public VipCarService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<VipCarDTO>> CreateVipCar(VipCarDTO vipCarDTO)
        {
            var obj = _mapper.Map<VipCarDTO, VipCar>(vipCarDTO);
            var addedObj = _context.VipCars.Add(obj);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<VipCar, VipCarDTO>(addedObj.Entity);
            return new ServiceResponse<VipCarDTO>
            {
                Data = response,
                Message = "Your process is success",
                Success = true,
            };
        }

        public async Task<ServiceResponse<bool>> DeleteVipCar(int id)
        {
            var obj = await _context.VipCars.FindAsync(id);
            if (obj == null)
            {
                return new ServiceResponse<bool>
                {
                    Message = "Your procces is fail",
                    Success = false,
                };
            }

            var deleteObj = _context.Remove(obj);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Message = "Your process is success",
                Success = true,
            };
        }

        public async Task<ServiceResponse<List<VipCar>>> GetAllVipCar()
        {
            var result = await _context.VipCars.ToListAsync();
            if (result == null)
            {
                return new ServiceResponse<List<VipCar>>
                {
                    Success = false,
                    Message = "Does not any item",
                };
            }
            return new ServiceResponse<List<VipCar>>
            {
                Data = result,
            };
        }

        public async Task<ServiceResponse<VipCarDTO>> GetByCar(int id)
        {
            var obj = await _context.VipCars.FirstOrDefaultAsync(x=>x.CarId == id);

            if (obj == null)
            {
                return new ServiceResponse<VipCarDTO>
                {
                    Success = false,
                    Message = "Your process is succes",
                };
            }
            var response = _mapper.Map<VipCar, VipCarDTO>(obj);
            return new ServiceResponse<VipCarDTO>
            {
                Data = response,
                Success = false,
                Message = "Your proccess is fail",
            };
        }

        public async Task<ServiceResponse<List<VipCar>>> GetFilterByVipCar(FilterForVipCar filterForVipCar)
        {
            //List<VipCar> vipCar = new List<VipCar>();
            var totalDay = filterForVipCar.DateOfReturn.Day - filterForVipCar.PurchaseDate.Day;

            if (filterForVipCar.Status == false)
            {
                var result = await _context.VipCars.
                    Where(x => x.PickupPlace.ToLower()
                    .Equals(filterForVipCar.PickupPlace.ToLower()) && x.DropOfLocation.ToLower().Equals(filterForVipCar.DropOfLocation.ToLower())
                    && x.PurchaseDate.Year == filterForVipCar.PurchaseDate.Year
                      && x.PurchaseDate.Month == filterForVipCar.PurchaseDate.Month
                        && x.PurchaseDate.Day == filterForVipCar.PurchaseDate.Day
                          && x.DateOfReturn.Year == filterForVipCar.DateOfReturn.Year
                        && x.DateOfReturn.Month == filterForVipCar.DateOfReturn.Month
                         && x.DateOfReturn.Day == filterForVipCar.DateOfReturn.Day
                         &&x.CarStatus == true
                    ).ToListAsync();

                foreach (var item in result)
                {
                    item.TotalPrice = item.DailyPrice * totalDay;
                }


                if (result.Count == 0)
                {
                    return new ServiceResponse<List<VipCar>>
                    {
                        Message = "Your process is failed",
                        Success = false,

                    };
                }

                return new ServiceResponse<List<VipCar>> { Data = result, Success = true, Message = "Successfully" };
            }
            else
            {
                var result = await _context.VipCars.
                  Where(x => x.PickupPlace.ToLower().Equals(filterForVipCar.PickupPlace.ToLower())
                  && x.DropOfLocation.ToLower().Equals(filterForVipCar.DropOfLocation.ToLower())
                  && x.PurchaseDate.Year == filterForVipCar.PurchaseDate.Year
                    && x.PurchaseDate.Month == filterForVipCar.PurchaseDate.Month
                      && x.PurchaseDate.Day == filterForVipCar.PurchaseDate.Day
                       && x.DateOfReturn.Year == filterForVipCar.DateOfReturn.Year
                        && x.DateOfReturn.Month == filterForVipCar.DateOfReturn.Month
                         && x.DateOfReturn.Day == filterForVipCar.DateOfReturn.Day
                  ).ToListAsync();


                if (result.Count  == 0)
                {
                    return new ServiceResponse<List<VipCar>>
                    {
                        Message = "Your process is failed",
                        Success = false,

                    };
                }

                return new ServiceResponse<List<VipCar>> { Data = result, Success = true, Message = "Successfully" };
            }
        }

        public async Task<ServiceResponse<VipCarDTO>> UpdateVipCar(VipCarDTO vipCarDTO)
        {
           
            var obj = _mapper.Map<VipCarDTO, VipCar>(vipCarDTO);
            var result = await _context.VipCars.FirstOrDefaultAsync(x => x.CarId == vipCarDTO.CarId);


            if (result == null)
            {
                return new ServiceResponse<VipCarDTO>
                {
                    Message = "Your process is failed",
                    Success = false,
                };
            }
            result.Company = obj.Company;
            result.PurchaseDate = obj.PurchaseDate;
            result.Deposit = obj.Deposit;
            result.DateOfReturn = obj.DateOfReturn;
            result.TotalKm = obj.TotalKm;
            result.Brand = obj.Brand;
            result.Model = obj.Model;
            result.PickupPlace = obj.PickupPlace;
            result.Description = obj.Description;
            result.DailyPrice = obj.DailyPrice;
            result.CarStatus = obj.CarStatus;
            var updateObj = _context.VipCars.Update(result);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<VipCar, VipCarDTO>(updateObj.Entity);
            return new ServiceResponse<VipCarDTO>
            {
                Message = "Your proccess is successfull",
                Success = true,
                Data = response,
            };



        }


        public async Task<ServiceResponse<List<VipCar>>> SearchText(string searchText)
        {
            var result = await _context.VipCars.
                Where(x => x.Brand.ToLower().Equals(searchText.ToLower()) 
                || 
                x.Model.ToLower().Equals(searchText.ToLower())).ToListAsync();
            if (result == null)
            {
                return new ServiceResponse<List<VipCar>>
                {
                    Success = false,
                    Message = "Process is fail",
                };
            }
            return new ServiceResponse<List<VipCar>>
            {
                Data = result,
                Success = true,
                Message = "Process is success",
            };

        }
    }
}
