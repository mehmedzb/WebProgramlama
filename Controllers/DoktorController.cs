using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.Controllers
{
    public class DoktorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorController(ApplicationDbContext context)
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
