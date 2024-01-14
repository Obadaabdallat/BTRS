using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTRS.Models;

namespace BTRS.Controllers
{
    public class BusesController : Controller
    {
        private readonly MyDBContext _context;

        public BusesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Buses
        public async Task<IActionResult> Index()
        {
              return _context.buses != null ? 
                          View(await _context.buses.ToListAsync()) :
                          Problem("Entity set 'MyDBContext.buses'  is null.");
        }

        // GET: Buses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.buses == null)
            {
                return NotFound();
            }

            var bus = await _context.buses
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // GET: Buses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusID,CaptinName,NumberOfSeets")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }

        // GET: Buses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.buses == null)
            {
                return NotFound();
            }

            var bus = await _context.buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusID,CaptinName,NumberOfSeets")] Bus bus)
        {
            if (id != bus.BusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.BusID))
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
            return View(bus);
        }

        // GET: Buses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.buses == null)
            {
                return NotFound();
            }

            var bus = await _context.buses
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.buses == null)
            {
                return Problem("Entity set 'MyDBContext.buses'  is null.");
            }
            var bus = await _context.buses.FindAsync(id);
            if (bus != null)
            {
                _context.buses.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.buses?.Any(e => e.BusID == id)).GetValueOrDefault();
        }
    }
}
