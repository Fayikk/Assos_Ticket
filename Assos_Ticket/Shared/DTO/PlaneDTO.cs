using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.DTO
{
    public class PlaneDTO
    {
        public int Id { get; set; }
        public string BusName { get; set; }
        public string Company { get; set; }
        public int SeatCount { get; set; }
    }
}
