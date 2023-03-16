using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public class FilterForPlane
    {
        public string Begin { get; set; }
        public string Finish { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public DateTime ReturnBack { get; set; }
        public bool ReturnStatus { get; set; }
    }
}
