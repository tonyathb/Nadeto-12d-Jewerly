using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewerly.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Jewerly.Controllers
{
    [Authorize]
    public class ShoppingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;
        
        public ShoppingsController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        // GET: Shoppings
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var applicationDbContext = _context.Shoppings.Include(s => s.Articuls).Include(s => s.Customers);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var currentUser = _userManager.GetUserId(User);
                var applicationDbContext = _context.Shoppings
                                    .Include(s => s.Articuls)
                                    .Include(s => s.Customers)
                                    .Where(s => s.CustomerId == currentUser);
            return View(await applicationDbContext.ToListAsync());
            }
            
        }

        // GET: Shoppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings
                .Include(s => s.Articuls)
                .Include(s => s.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // GET: Shoppings/Create
        public IActionResult Create()
        {
            ViewData["ArticulId"] = new SelectList(_context.Articuls, "Id", "Name");
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Shoppings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticulId,Quantity")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.GetUserId(User);
                shopping.RegisterOn = DateTime.Now;
                shopping.CustomerId = currentUser;
                _context.Shoppings.Add(shopping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticulId"] = new SelectList(_context.Articuls, "Id", "Name", shopping.ArticulId);
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Name", shopping.CustomerId);
            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings.FindAsync(id);
            if (shopping == null)
            {
                return NotFound();
            }
            ViewData["ArticulId"] = new SelectList(_context.Articuls, "Id", "Name", shopping.ArticulId);
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Name", shopping.CustomerId);
            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticulId,Quantity")] Shopping shopping)
        {
            if (id != shopping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = _userManager.GetUserId(User);
                    shopping.RegisterOn = DateTime.Now;
                    shopping.CustomerId = currentUser;
                    _context.Shoppings.Update(shopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExists(shopping.Id))
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
            ViewData["ArticulId"] = new SelectList(_context.Articuls, "Id", "Name", shopping.ArticulId);
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Name", shopping.CustomerId);
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings
                .Include(s => s.Articuls)
                .Include(s => s.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shoppings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shoppings'  is null.");
            }
            var shopping = await _context.Shoppings.FindAsync(id);
            if (shopping != null)
            {
                _context.Shoppings.Remove(shopping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingExists(int id)
        {
          return (_context.Shoppings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
