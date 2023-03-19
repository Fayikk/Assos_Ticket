using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }        
        public int? UserId { get; set; }
        public int? BusId { get; set; }
        public int? PlaneId { get; set; }
        public int? VipCarId { get; set; }
        [Required]
        public int DiscountAmount { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }
    }
}
