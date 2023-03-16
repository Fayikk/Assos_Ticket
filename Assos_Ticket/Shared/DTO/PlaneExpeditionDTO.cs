using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.DTO
{
    public class PlaneExpeditionDTO
    {
        public int Id { get; set; }
        public string PlaneName { get; set; }
        public string Company { get; set; }
        public int Capacity { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public DateTime ReturnBack { get; set; }
        public bool ReturnStatus { get; set; } = false;
        public string Begining { get; set; }
        public bool TransferStatus { get; set; } = true;
        public string Finish { get; set; }
        public DateTime CreatedDate { get; set; }
        public Decimal Price { get; set; }

        public bool Status { get; set; } = true;
    }
}
