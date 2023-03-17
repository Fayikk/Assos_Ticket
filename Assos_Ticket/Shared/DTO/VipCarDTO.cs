using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.DTO
{
    public class VipCarDTO
    {
        public int CarId { get; set; }
        public string Company { get; set; } = string.Empty;
        public Decimal Deposit { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int TotalKm { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string PickupPlace { get; set; }
        public string Description { get; set; }
        public Decimal DailyPrice { get; set; }
        public bool CarStatus { get; set; }
        public string DropOfLocation { get; set; }

    }
}
