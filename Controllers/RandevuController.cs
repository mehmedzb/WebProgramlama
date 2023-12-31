﻿using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneWeb.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Randevular != null ?
                View(await _context.Randevular.Include(d => d.Doktor).Include(d => d.Hasta).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Randevular'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(d => d.Doktor)
                .Include(h => h.Hasta)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        public IActionResult Create()
        {
            ViewBag.Doktorlar = _context.Doktorlar.ToListAsync();
            ViewBag.Hastalar = _context.Hastalar.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Randevu randevu)
        {
            if (ModelState.IsValid || true)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Doktorlar = _context.Doktorlar.ToListAsync();
            ViewBag.Hastalar = _context.Hastalar.ToListAsync();

            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Randevu randevu)
        {
            if (id != randevu.RandevuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid || true)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuID))
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
            return View(randevu);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(d => d.Doktor)
                .Include(h => h.Hasta)
                .FirstOrDefaultAsync(m => m.RandevuID == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Randevular == null) 
            {
                return Problem("Entity set 'ApplicationDbContext.Randevular' is null.");
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if(randevu != null) 
            {
                _context.Randevular.Remove(randevu);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuID == id);
        }

    }
}
