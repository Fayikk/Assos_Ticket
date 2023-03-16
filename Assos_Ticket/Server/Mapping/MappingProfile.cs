using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using AutoMapper;

namespace Assos_Ticket.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusExpedition,BusExpeditionDTO>().ReverseMap();
            CreateMap<PlaneExpedition,PlaneExpeditionDTO>().ReverseMap();
        }
    }
}
