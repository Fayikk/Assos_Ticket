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
        public int UserId { get; set; }
        [Required]
        public DateTime BoughtDate { get; set; }    
        

    }
}
