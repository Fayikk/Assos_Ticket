using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Plane
    {
        [Key]
        public int PlaneId { get; set; }
        [Required]
        public string PlaneName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Capacity { get; set; }  
        public List<Expedition> Expeditions { get; set; }
    }
}
