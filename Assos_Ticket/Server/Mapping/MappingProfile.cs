using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using AutoMapper;

namespace Assos_Ticket.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bus,BusDTO>().ReverseMap();
            CreateMap<Plane,PlaneDTO>().ReverseMap();
        }
    }
}
