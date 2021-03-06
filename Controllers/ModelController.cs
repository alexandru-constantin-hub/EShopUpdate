using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop1.Data;
using EShop1.Models;

namespace EShop1.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Model
        public async Task<IActionResult> Index()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View(await _context.Models.ToListAsync());
        }

        // GET: Model/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View(model);
        }

        // GET: Model/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        // POST: Model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,ModelName,BrandId")] Model model)
        {
            var checkModel = this._context.Models.Any(o => (o.ModelName.ToLower() == model.ModelName.ToLower() && o.BrandId == model.BrandId));
            if (checkModel)
            {
                TempData["Message"] = "The model for this brand already exists. Please check again.";
            }

            if (ModelState.IsValid && !checkModel)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View(model);
        }

        // GET: Model/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View(model);
        }

        // POST: Model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelId,ModelName,BrandId")] Model model)
        {
            var checkModel = this._context.Models.Any(o => (o.ModelName.ToLower() == model.ModelName.ToLower() && o.BrandId == model.BrandId));
            if (checkModel)
            {
                TempData["Message"] = "The model for this brand already exists. Please check again.";
            }

            if (id != model.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && !checkModel)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.ModelId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View(model);
        }

        // GET: Model/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Models.FindAsync(id);
            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.ModelId == id);
        }
    }
}
