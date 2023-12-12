using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        public Doktor Doktor { get; set; }
        public Hasta Hasta { get; set; }
        
    }
}
