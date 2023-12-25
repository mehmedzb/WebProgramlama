using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        public Doktor Doktor { get; set; }
        public Hasta Hasta { get; set; }
        
    }
}
