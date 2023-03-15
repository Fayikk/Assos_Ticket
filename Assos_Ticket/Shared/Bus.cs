using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        public string BusName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Capacitiy { get; set; }  
        public List<Expedition> Expeditions { get; set; }

    }
}
