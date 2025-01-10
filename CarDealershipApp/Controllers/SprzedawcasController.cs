using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApp.Controllers
{
    public class SprzedawcasController : Controller
    {
        private readonly KomisContext _context;

        public SprzedawcasController(KomisContext context)
        {
            _context = context;
        }

        // GET: Sprzedawcas
        public async Task<IActionResult> Index()
        {
              return _context.Sprzedawcy != null ? 
                          View(await _context.Sprzedawcy.ToListAsync()) :
                          Problem("Entity set 'KomisContext.Sprzedawcy'  is null.");
        }

        // GET: Sprzedawcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sprzedawcy == null)
            {
                return NotFound();
            }

            var sprzedawca = await _context.Sprzedawcy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprzedawca == null)
            {
                return NotFound();
            }

            return View(sprzedawca);
        }

        // GET: Sprzedawcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sprzedawcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Email,Telefon,DataZatrudnienia")] Sprzedawca sprzedawca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzedawca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprzedawca);
        }

        // GET: Sprzedawcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sprzedawcy == null)
            {
                return NotFound();
            }

            var sprzedawca = await _context.Sprzedawcy.FindAsync(id);
            if (sprzedawca == null)
            {
                return NotFound();
            }
            return View(sprzedawca);
        }

        // POST: Sprzedawcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Email,Telefon,DataZatrudnienia")] Sprzedawca sprzedawca)
        {
            if (id != sprzedawca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprzedawca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprzedawcaExists(sprzedawca.Id))
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
            return View(sprzedawca);
        }

        // GET: Sprzedawcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sprzedawcy == null)
            {
                return NotFound();
            }

            var sprzedawca = await _context.Sprzedawcy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprzedawca == null)
            {
                return NotFound();
            }

            return View(sprzedawca);
        }

        // POST: Sprzedawcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sprzedawcy == null)
            {
                return Problem("Entity set 'KomisContext.Sprzedawcy'  is null.");
            }
            var sprzedawca = await _context.Sprzedawcy.FindAsync(id);
            if (sprzedawca != null)
            {
                _context.Sprzedawcy.Remove(sprzedawca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprzedawcaExists(int id)
        {
          return (_context.Sprzedawcy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
