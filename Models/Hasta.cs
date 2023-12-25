using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.Models
{
    public class Hasta
    {
        [Key]
        public int HastaID { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public int HastaYas { get; set; }

    }
}
