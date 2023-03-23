using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class RezervePlane
    {
        [Key]
        public int ReservePLaneId { get; set; }
        public int ConversationId { get; set; } 
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Luggage { get; set; } = 15;//15 kilodan sonra her kilo için extra
        public DateTime DepartureDate { get; set; } //
        public string? Transfer { get; set; } = "Direct"; //Şimdilik aktarmaların hepsi direk
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        public string TravelTime { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }

    }
}
