using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared.Model
{
    public  class PaymentModel
    {
        public string CardHolderName { get; set; }    
        public string Surname { get; set; }   
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpireMonth { get; set; }   
        public string ExpireYear { get; set;}
        public string Cvc { get; set; } 

    }
}
