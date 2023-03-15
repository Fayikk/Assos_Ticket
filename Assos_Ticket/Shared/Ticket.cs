using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public DateTime BoughtDate { get; set; }    
        public Customer Customer { get; set; }  
        public Expedition Expedition { get; set; }
        [Required]
        public int SeatNo { get; set; } 
    }
}
