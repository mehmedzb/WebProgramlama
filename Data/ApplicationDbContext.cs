using HastaneWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
    }
}