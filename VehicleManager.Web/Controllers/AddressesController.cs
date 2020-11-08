using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleManager.Domain.Model;
using VehicleManager.Infrastructure;

namespace VehicleManager.Web.Controllers
{
    public class AddressesController : Controller
    {
        private readonly Context _context;

        public AddressesController(Context context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var context = _context.Addresses.Include(a => a.AddressType).Include(a => a.ApplicationUser).Include(a => a.City).Include(a => a.Country).Include(a => a.ZipCode);
            return View(await context.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressType)
                .Include(a => a.ApplicationUser)
                .Include(a => a.City)
                .Include(a => a.Country)
                .Include(a => a.ZipCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["AddressTypeRef"] = new SelectList(_context.AddressTypes, "Id", "Id");
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["CityRef"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["CountryRef"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["ZipCodeRef"] = new SelectList(_context.ZipCodes, "Id", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,BuildigNumber,FlatNumber,AddressTypeRef,CityRef,ZipCodeRef,CountryRef,ApplicationUserID,CreatedById,CreatedDateTime,ModifiedById,ModifiedDateTime")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressTypeRef"] = new SelectList(_context.AddressTypes, "Id", "Id", address.AddressTypeRef);
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", address.ApplicationUserID);
            ViewData["CityRef"] = new SelectList(_context.Cities, "Id", "Name", address.CityRef);
            ViewData["CountryRef"] = new SelectList(_context.Countries, "Id", "Name", address.CountryRef);
            ViewData["ZipCodeRef"] = new SelectList(_context.ZipCodes, "Id", "Name", address.ZipCodeRef);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["AddressTypeRef"] = new SelectList(_context.AddressTypes, "Id", "Id", address.AddressTypeRef);
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", address.ApplicationUserID);
            ViewData["CityRef"] = new SelectList(_context.Cities, "Id", "Name", address.CityRef);
            ViewData["CountryRef"] = new SelectList(_context.Countries, "Id", "Name", address.CountryRef);
            ViewData["ZipCodeRef"] = new SelectList(_context.ZipCodes, "Id", "Name", address.ZipCodeRef);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Street,BuildigNumber,FlatNumber,AddressTypeRef,CityRef,ZipCodeRef,CountryRef,ApplicationUserID,CreatedById,CreatedDateTime,ModifiedById,ModifiedDateTime")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["AddressTypeRef"] = new SelectList(_context.AddressTypes, "Id", "Id", address.AddressTypeRef);
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUsers, "Id", "Id", address.ApplicationUserID);
            ViewData["CityRef"] = new SelectList(_context.Cities, "Id", "Name", address.CityRef);
            ViewData["CountryRef"] = new SelectList(_context.Countries, "Id", "Name", address.CountryRef);
            ViewData["ZipCodeRef"] = new SelectList(_context.ZipCodes, "Id", "Name", address.ZipCodeRef);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressType)
                .Include(a => a.ApplicationUser)
                .Include(a => a.City)
                .Include(a => a.Country)
                .Include(a => a.ZipCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
