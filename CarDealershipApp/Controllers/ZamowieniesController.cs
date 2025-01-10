using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApp.Controllers
{
    public class ZamowieniesController : Controller
    {
        private readonly KomisContext _context;

        public ZamowieniesController(KomisContext context)
        {
            _context = context;
        }

        // GET: Zamowienies
        public async Task<IActionResult> Index()
        {
            var komisContext = _context.Zamowienia.Include(z => z.Klient).Include(z => z.Samochod).Include(z => z.Sprzedawca);
            return View(await komisContext.ToListAsync());
        }

        // GET: Zamowienies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Klient)
                .Include(z => z.Samochod)
                .Include(z => z.Sprzedawca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienies/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Imie");
            ViewData["SamochodId"] = new SelectList(_context.Samochody, "Id", "Marka");
            ViewData["SprzedawcaId"] = new SelectList(_context.Sprzedawcy, "Id", "Imie");
            return View();
        }

        // POST: Zamowienies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KlientId,SamochodId,SprzedawcaId")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Imie", zamowienie.KlientId);
            ViewData["SamochodId"] = new SelectList(_context.Samochody, "Id", "Marka", zamowienie.SamochodId);
            ViewData["SprzedawcaId"] = new SelectList(_context.Sprzedawcy, "Id", "Imie", zamowienie.SprzedawcaId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Imie", zamowienie.KlientId);
            ViewData["SamochodId"] = new SelectList(_context.Samochody, "Id", "Marka", zamowienie.SamochodId);
            ViewData["SprzedawcaId"] = new SelectList(_context.Sprzedawcy, "Id", "Imie", zamowienie.SprzedawcaId);
            return View(zamowienie);
        }

        // POST: Zamowienies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlientId,SamochodId,SprzedawcaId")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klienci, "Id", "Imie", zamowienie.KlientId);
            ViewData["SamochodId"] = new SelectList(_context.Samochody, "Id", "Marka", zamowienie.SamochodId);
            ViewData["SprzedawcaId"] = new SelectList(_context.Sprzedawcy, "Id", "Imie", zamowienie.SprzedawcaId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.Klient)
                .Include(z => z.Samochod)
                .Include(z => z.Sprzedawca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zamowienia == null)
            {
                return Problem("Entity set 'KomisContext.Zamowienia'  is null.");
            }
            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie != null)
            {
                _context.Zamowienia.Remove(zamowienie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
          return (_context.Zamowienia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
