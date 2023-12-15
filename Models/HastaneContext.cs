using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HastaneRandevu.Models
{
    public class HastaneContext : DbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> options) : base(options)
        {
            
        }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

    }
}
