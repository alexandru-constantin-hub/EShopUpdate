using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop1.Data;

namespace EShop1.Models
{
    public class SellPriceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellPriceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Price
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellPrices.ToListAsync());
        }

        // GET: Price/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellPrice = await _context.SellPrices
                .FirstOrDefaultAsync(m => m.SellPriceId == id);
            if (sellPrice == null)
            {
                return NotFound();
            }

            return View(sellPrice);
        }

        // GET: Price/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Price/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SellPrice sellPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellPrice);
        }

        // GET: Price/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellPrice = await _context.SellPrices.FindAsync(id);
            if (sellPrice == null)
            {
                return NotFound();
            }
            return View(sellPrice);
        }

        // POST: Price/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SellPrice sellPrice)
        {
            if (id != sellPrice.SellPriceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellPriceExists(sellPrice.SellPriceId))
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
            return View(sellPrice);
        }

        // GET: Price/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellPrice = await _context.SellPrices
                .FirstOrDefaultAsync(m => m.SellPriceId == id);
            if (sellPrice == null)
            {
                return NotFound();
            }

            return View(sellPrice);
        }

        // POST: Price/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellPrice = await _context.SellPrices.FindAsync(id);
            _context.SellPrices.Remove(sellPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellPriceExists(int id)
        {
            return _context.SellPrices.Any(e => e.SellPriceId == id);
        }
    }
}
