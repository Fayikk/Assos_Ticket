using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class PlaneExpedition
    {
        [Key]
        public int PlaneId { get; set; }
        [Required]
        public string PlaneName { get; set; }
        [Required]
        public string Company { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime BeginingDate { get; set; }
        [Required]
        public DateTime FinisingDate { get; set; }
        [Required]
        public DateTime ReturnBack { get; set; }
        [Required]
        public bool ReturnStatus { get; set; } = false;
        [Required]
        public string Begining { get; set; }
        [Required]
        public bool TransferStatus { get; set; } = true;
        [Required]  
        public string Finish { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        public Decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool Status { get; set; } = true;
    }
}
