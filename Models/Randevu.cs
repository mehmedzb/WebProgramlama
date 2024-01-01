using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneWeb.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        [ForeignKey("Doktor")]
        public int DoktorID { get; set; }
        public virtual Doktor Doktor { get; set; }
        [ForeignKey("Hasta")]
        public int HastaID { get; set; }
        public virtual Hasta Hasta { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Randevu Tarihi")]
        public DateTime RandevuTarih { get; set; }
    }
}
