using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Expedition
    {
        [Key]
        public int ExpeditionId { get; set; }
        public int? BusId { get; set; }
        public int? PlaneId { get; set; }    
        public List<BusExpedition> BusExpeditions { get; set; }
        public List<PlaneExpedition> PlaneExpeditions { get; set; }
    }
}
