using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneWeb.Controllers
{
    public class HastaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Hastalar != null ?
                View(await _context.Hastalar.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Hastalar'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FirstOrDefaultAsync(m => m.HastaID == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastaID , HastaAd , HastaSoyad , HastaYas")] Hasta hasta)
        {
            if (ModelState.IsValid || true)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HastaID , HastaAd , HastaSoyad , HastaYas")] Hasta hasta)
        {
            if (id != hasta.HastaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaExists(hasta.HastaID))
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
            return View(hasta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastalar == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FirstOrDefaultAsync(m => m.HastaID == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Hastalar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hastalar'  is null.");
            }

            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta != null)
            {
                _context.Hastalar.Remove(hasta);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
            return _context.Hastalar.Any(e => e.HastaID == id);
        }
    }
}
