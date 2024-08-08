using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Controllers
{
    public class MagicsController : Controller
    {
        private readonly WebSalesContext _context;

        public MagicsController(WebSalesContext context)
        {
            _context = context;
        }

        // GET: Magics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magics.ToListAsync());
        }

        // GET: Magics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magics = await _context.Magics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magics == null)
            {
                return NotFound();
            }

            return View(magics);
        }

        // GET: Magics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Magics magics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magics);
        }

        // GET: Magics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magics = await _context.Magics.FindAsync(id);
            if (magics == null)
            {
                return NotFound();
            }
            return View(magics);
        }

        // POST: Magics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Magics magics)
        {
            if (id != magics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagicsExists(magics.Id))
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
            return View(magics);
        }

        // GET: Magics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magics = await _context.Magics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magics == null)
            {
                return NotFound();
            }

            return View(magics);
        }

        // POST: Magics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magics = await _context.Magics.FindAsync(id);
            if (magics != null)
            {
                _context.Magics.Remove(magics);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagicsExists(int id)
        {
            return _context.Magics.Any(e => e.Id == id);
        }
    }
}
