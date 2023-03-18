using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class VipCar
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Company { get; set; } = string.Empty;
        [Column(TypeName = "Decimal(18,2)")]
        [Required]

        public Decimal Deposit { get; set; }
        [Required]

        public DateTime PurchaseDate { get; set; }
        [Required]

        public DateTime DateOfReturn { get; set; }
     
        [Required]
        public int TotalKm { get; set; }
        [Required]

        public string Brand { get; set; } = string.Empty;
        [Required]

        public string Model { get; set; } = string.Empty;
        [Required]

        public string PickupPlace { get; set; }
        [Required]
        public string DropOfLocation { get; set; }  
        [Required]

        public string Description { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        [Required]
        public Decimal DailyPrice { get; set; }
        [Required]
        public bool CarStatus { get; set; }
        public string? ImageUrl { get; set; }
    }
}
