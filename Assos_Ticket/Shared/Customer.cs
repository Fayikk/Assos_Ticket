using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string Email { get; set; }
    }
}
