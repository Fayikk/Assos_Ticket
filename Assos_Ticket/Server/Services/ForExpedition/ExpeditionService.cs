using Assos_Ticket.Server.Context;
using Assos_Ticket.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Assos_Ticket.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Assos_Ticket.Server.Services.ForExpedition
{
    public class ExpeditionService : IExpeditionService
    {
        private readonly DataContext _context;
        public ExpeditionService(DataContext context)
        {
            _context = context;
        }

        

     
    }
}
