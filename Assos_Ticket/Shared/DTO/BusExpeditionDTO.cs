using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.DTO
{
    public class BusExpeditionDTO
    {
        public int Id { get; set; }
        public string BusName { get; set; }
        public string Company { get; set; }
        public int Capacitiy { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public string Begining { get; set; }
        public string Finish { get; set; }
        public DateTime CreatedDate { get; set; }
        public Decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
