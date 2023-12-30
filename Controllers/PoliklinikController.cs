using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneWeb.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliklinikController(ApplicationDbContext context)
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

        public IActionResult Edit()
        {
            return View();
        }   

        public IActionResult Delete() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Poliklinik poliklinik) 
        {
            if (!ModelState.IsValid) return View(poliklinik);
            _context.Poliklinikler.Add(poliklinik);
            return RedirectToAction("Index");
        }

    }
}
