using HastaneRandevu.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class DoktorController : Controller
    {
        private readonly HastaneContext _context;

        public DoktorController(HastaneContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Doktor> doktorlar = _context.Doktorlar.ToList();
            if(doktorlar == null) { return NotFound(); }
            return View(doktorlar);
        }

        public IActionResult Create()
        {
            return View();
        } 

    }
}
