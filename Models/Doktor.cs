using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneWeb.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        public string DoktorAd{ get; set; }
        public string DoktorSoyad { get; set; }
        [ForeignKey("Poliklinik")]
        public int PoliklinikID { get; set; }
        public virtual Poliklinik Poliklinik { get; set; }

        public virtual ICollection<Randevu> Randevular { get; set; }
    }
}
