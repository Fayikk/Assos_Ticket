using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class OrderBus
    {
       
        [Key]
        public int Id { get; set; }
        public int BusId { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; } 
        public bool Gender { get; set; }    
        [Required]
        public int SeatNo { get; set; }
        [Column(TypeName ="Decimal(18,2)")]
        public Decimal Price { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Rotate { get; set; }
        public bool Status { get; set; } = true;


    }
}
