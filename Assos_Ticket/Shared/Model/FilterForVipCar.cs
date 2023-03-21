using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public class FilterForVipCar
    {
        public string PickupPlace { get; set; }
        public string DropOfLocation { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DateOfReturn { get; set; }
   

    }
}
