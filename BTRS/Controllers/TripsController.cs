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
    public class TripsController : Controller
    {
        private readonly MyDBContext _context;

        public TripsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            return _context.trips != null ?
                        View(await _context.trips.ToListAsync()) :
                        Problem("Entity set 'MyDBContext.trips'  is null.");
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.trips == null)
            {
                return NotFound();
            }

            var trip = await _context.trips
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,StartDate,EndDate,BusNumber,TripDis")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.trips == null)
            {
                return NotFound();
            }

            var trip = await _context.trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,StartDate,EndDate,BusNumber,TripDis")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
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
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.trips == null)
            {
                return NotFound();
            }

            var trip = await _context.trips
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trips == null)
            {
                return Problem("Entity set 'MyDBContext.trips'  is null.");
            }
            var trip = await _context.trips.FindAsync(id);
            if (trip != null)
            {
                _context.trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
       
        
        public IActionResult AddtoMyTrips(int id)

        {

            var trp = from t in _context.trips
                      where t.TripID == id
                      select t;

            Trip trip = trp.FirstOrDefault();
            int pid = 1;

            Booking booking = new Booking();
            booking.PassengerID = pid;
            booking.TripID = trip.TripID;

            _context.bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("PassengerBookings", "User");



           

            // get the trip from databe (ling)
            // insert to booking table trip id (qury result)
            //insert passenger id (session when log in)
        }



        private bool TripExists(int id)
        {
          return (_context.trips?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
