using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assos_Ticket.Server.Services.ForExpedition
{
    public class ExpeditionService : IExpeditionService
    {
        private readonly DataContext _context;
        public ExpeditionService(DataContext context)
        {
            _context = context;
        }

        //public async Task<ServiceResponse<Expedition>> CreateExpedition(Expedition expedition)
        //{
        //    expedition.CreatedDate = DateTime.UtcNow;
        //    _context.Expeditions.Add(expedition);
        //    await _context.SaveChangesAsync();
        //    return new ServiceResponse<Expedition>
        //    {
        //        Message = "Your process is success",
        //        Data = expedition,
        //        Success = true,
        //    };
        
        //}
    }
}
//public DateTime ExpedititonDate { get; set; }
//[Required]
//public string Begining { get; set; }
//[Required]
//public string Finish { get; set; }
//[Required]
//[Column(TypeName = "Decimal(18,2)")]
//public DateTime CreatedDate { get; set; }
//public Decimal Price { get; set; }
//public bool Status { get; set; }
//public List<Bus> Busses { get; set; }
//public List<Plane> Planes { get; set; }