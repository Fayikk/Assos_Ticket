using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public int? VipCarId { get; set; }
        public int? BusId { get; set; }
        public int? PlaneId { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageUrl { get; set; } 
        public DateTime Date { get; set; }
    }

}

