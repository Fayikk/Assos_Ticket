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
        [Required]
        public DateTime BeginingDate { get; set; }
        [Required]
        public DateTime FinisingDate { get; set; }
        [Required]
        public string Begining { get; set; }
        [Required]
        public string Finish { get; set; }
        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        public DateTime CreatedDate { get; set; }
        public Decimal Price { get; set; }
        public bool Status { get; set; }
        public Bus Bus { get; set; }
        public Plane Plane { get; set; }
        public List<Ticket> Tickets { get; set; }   
    }
}
