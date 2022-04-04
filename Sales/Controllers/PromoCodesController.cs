using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales.DataLayer.Context;
using Sales.DataLayer.Entities;

namespace Sales.App.Controllers
{
    public class PromoCodesController : Controller
    {
        private readonly SalesContext _context;

        public PromoCodesController(SalesContext context)
        {
            _context = context;
        }

        // GET: PromoCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PromoCodes.ToListAsync());
        }

        // GET: PromoCodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoCode = await _context.PromoCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promoCode == null)
            {
                return NotFound();
            }

            return View(promoCode);
        }

        // GET: PromoCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,IsValid")] PromoCode promoCode)
        {
            if (ModelState.IsValid)
            {
                promoCode.Id = Guid.NewGuid();
                _context.Add(promoCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoCode);
        }

        // GET: PromoCodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode == null)
            {
                return NotFound();
            }
            return View(promoCode);
        }

        // POST: PromoCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,IsValid")] PromoCode promoCode)
        {
            if (id != promoCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoCodeExists(promoCode.Id))
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
            return View(promoCode);
        }

        // GET: PromoCodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoCode = await _context.PromoCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promoCode == null)
            {
                return NotFound();
            }

            return View(promoCode);
        }

        // POST: PromoCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoCodeExists(Guid id)
        {
            return _context.PromoCodes.Any(e => e.Id == id);
        }
    }
}
