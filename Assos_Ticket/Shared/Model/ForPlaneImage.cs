using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public class ForPlaneImage
    {
        public int Id { get; set; }
        public int PlaneId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
