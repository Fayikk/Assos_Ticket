using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public class ForCarImages
    {
        public int Id { get; set; }
        public int VipCarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
