﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class RezerveVipCar
    {
        [Key]
        public int RezerveVipCarId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        [Column(TypeName ="Decimal(18,2)")]
        public decimal? Deposit { get; set; }
        public string? Group { get; set; } //Economic Vb
        //public string? CouponCode { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal? TotalPrice { get; set; }
        public string? PickupPlace { get; set; }
        public string? DropOfLocation { get; set; }
      
    }
}
