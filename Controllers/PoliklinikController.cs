using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return _context.Poliklinikler != null ?
                View(await _context.Poliklinikler.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Poliklinikler'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Poliklinikler == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinikler
                .FirstOrDefaultAsync(m => m.PoliklinikID == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoliklinikID , PoliklinikAd ")]Poliklinik poliklinik)
        {
            if (ModelState.IsValid || true)
            {
                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Poliklinikler == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinikler.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoliklinikID , PoliklinikAd ")] Poliklinik poliklinik)
        {
            if (id != poliklinik.PoliklinikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(poliklinik.PoliklinikID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Poliklinikler == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinikler
                .FirstOrDefaultAsync(m => m.PoliklinikID == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Poliklinikler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Poliklinikler'  is null.");
            }

            var poliklinik = await _context.Poliklinikler.FindAsync(id);
            if (poliklinik != null) 
            {
                _context.Poliklinikler.Remove(poliklinik);
            } 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
            return _context.Poliklinikler.Any(e => e.PoliklinikID == id);
        }
        

    }
}
