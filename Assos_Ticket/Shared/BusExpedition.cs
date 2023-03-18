using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class BusExpedition
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        public string BusName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Capacitiy { get; set; }
        [Required]
        public DateTime BeginingDate { get; set; }
        [Required]
        public DateTime FinisingDate { get; set; }
        [Required]
        public string Begining { get; set; }
        [Required]
        public string Finish { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        public Decimal Price { get; set; }
        public bool Status { get; set; }
        public string? ImageUrl { get; set; }

    }
}
