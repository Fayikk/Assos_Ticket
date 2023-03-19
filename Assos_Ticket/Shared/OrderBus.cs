using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assos_Ticket.Shared
{
    public class OrderBus
    {
        //Kapasite aşılmamalı
        //İlgili Koltuk Doluysa Uyarmalı
        //Seiçlen Koltuk Numarasının sınırları belli olmalıdır
        //Erkek ve kadın yan yana oturamaz (1-2,3-4,5-6...gibi)//eğer seçilen koltuk numarası tek ise bir sonraki koltuk,çift ise bir önceki koltuk kontrol edilir.
        [Key]
        public int Id { get; set; }
        public int BusId { get; set; }
        public int UserId { get; set; }
        
        public bool Gender { get; set; }    
        [Required]
        public int SeatNo { get; set; }
        [Column(TypeName ="Decimal(18,2)")]
        public Decimal Price { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Rotate { get; set; }
        public bool Status { get; set; } = true;


    }
}
