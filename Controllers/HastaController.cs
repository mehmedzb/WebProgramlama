using HastaneRandevu.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class HastaController : Controller
    {
        private readonly HastaneContext _context;

        public HastaController(HastaneContext context)
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
