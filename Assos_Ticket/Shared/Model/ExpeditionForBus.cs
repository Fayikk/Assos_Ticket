using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public class ExpeditionForBus
    {
        public int ExpeditionId { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public string Begining { get; set; }
        public string Finish { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public BusExpedition? Bus { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
