using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikID { get; set; }
        public string PoliklinikAd{ get; set; }


    }
}
