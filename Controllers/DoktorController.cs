using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneWeb.Controllers
{
    public class DoktorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Doktorlar != null ?
                View(await _context.Doktorlar.Include(d => d.Poliklinik).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Doktorlar'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .Include(d => d.Poliklinik)
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        public IActionResult Create()
        {
            ViewBag.Poliklinikler = _context.Poliklinikler.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doktor doktor)
        {
            if (ModelState.IsValid || true)
            {
                _context.Doktorlar.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Poliklinikler = _context.Poliklinikler.ToListAsync();

            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid || true)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorID))
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
            return View(doktor);
        }

        // GET: AuthorAuto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktorlar == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.Include(d => d.Poliklinik)
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: AuthorAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktorlar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doktorlar'  is null.");
            }
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return (_context.Doktorlar?.Any(e => e.DoktorID == id)).GetValueOrDefault();
        }

    }
}
