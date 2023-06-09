﻿using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForVipCarRezerve
{
    public interface IVipCarRezerveService
    {
        Task<ServiceResponse<RezerveVipCar>> CreateVipCarRezerve(int vipCarId);
        Task<ServiceResponse<List<RezerveVipCar>>> ListMyRezerve();
        Task<ServiceResponse<bool>> ToSubmitCar(int id);
    }
}
