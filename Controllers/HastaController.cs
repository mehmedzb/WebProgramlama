using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.Controllers
{
    public class HastaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Hasta> hastalar = _context.Hastalar.ToList();
            if(hastalar == null) return NotFound();
            return View(hastalar);
        }
    }
}
