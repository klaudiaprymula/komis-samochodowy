using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApp.Controllers
{
   
    public class SamochodsController : Controller
    {
        private readonly KomisContext _context;

        public SamochodsController(KomisContext context)
        {
            _context = context;
        }

        // GET: Samochods
        public async Task<IActionResult> Index()
        {
              return _context.Samochody != null ? 
                          View(await _context.Samochody.ToListAsync()) :
                          Problem("Entity set 'KomisContext.Samochody'  is null.");
        }

        // GET: Samochods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Samochody == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        [Authorize(Roles = "Sprzedawca")]
        // GET: Samochods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samochods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,Cena,RokProdukcji,Dostepnosc")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samochod);
        }

        [Authorize(Roles = "Sprzedawca")]
        // GET: Samochods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samochody == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            return View(samochod);
        }

        // POST: Samochods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,Cena,RokProdukcji,Dostepnosc")] Samochod samochod)
        {
            if (id != samochod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.Id))
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
            return View(samochod);
        }


        [Authorize(Roles = "Sprzedawca")]
        // GET: Samochods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samochody == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Samochody == null)
            {
                return Problem("Entity set 'KomisContext.Samochody'  is null.");
            }
            var samochod = await _context.Samochody.FindAsync(id);
            if (samochod != null)
            {
                _context.Samochody.Remove(samochod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
          return (_context.Samochody?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
