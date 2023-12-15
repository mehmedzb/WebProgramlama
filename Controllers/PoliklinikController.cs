using HastaneRandevu.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly HastaneContext _context;

        public PoliklinikController(HastaneContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Poliklinik> poliklinikler = _context.Poliklinikler.ToList();
            if(poliklinikler == null) return  NotFound(); 
            return View(poliklinikler);
        }

        public IActionResult Details() 
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

    }
}
