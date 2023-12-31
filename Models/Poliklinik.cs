using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikID { get; set; }
        public string PoliklinikAd{ get; set; }
    }
}
