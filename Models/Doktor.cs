using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        public string DoktorAd{ get; set; }

        public string DoktorSoyad { get; set; }

        public Poliklinik Poliklinik { get; set; }

    }
}
