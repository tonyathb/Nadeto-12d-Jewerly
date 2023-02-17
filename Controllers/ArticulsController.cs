using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewerly.Data;

namespace Jewerly.Controllers
{
    public class ArticulsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articuls
        public async Task<IActionResult> Index()
        {
              return View(await _context.Articuls.ToListAsync());
        }

        // GET: Articuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articuls == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // GET: Articuls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Category,Type,ImageUrl,Price,Description,RegisterOn")] Articul articul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articul);
        }

        // GET: Articuls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articuls == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls.FindAsync(id);
            if (articul == null)
            {
                return NotFound();
            }
            return View(articul);
        }

        // POST: Articuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Category,Type,ImageUrl,Price,Description,RegisterOn")] Articul articul)
        {
            if (id != articul.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulExists(articul.Id))
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
            return View(articul);
        }

        // GET: Articuls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articuls == null)
            {
                return NotFound();
            }

            var articul = await _context.Articuls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // POST: Articuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articuls == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articuls'  is null.");
            }
            var articul = await _context.Articuls.FindAsync(id);
            if (articul != null)
            {
                _context.Articuls.Remove(articul);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulExists(int id)
        {
          return _context.Articuls.Any(e => e.Id == id);
        }
    }
}
