using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NannaKlean.Data;
using NannaKlean.Models;

namespace NannaKlean.Views
{
    public class MiscItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiscItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MiscItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiscItem.ToListAsync());
        }

        // GET: MiscItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItem = await _context.MiscItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miscItem == null)
            {
                return NotFound();
            }

            return View(miscItem);
        }

        // GET: MiscItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiscItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,requested,ResCleanDetailId,MiscItemTypeId")] MiscItem miscItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miscItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miscItem);
        }

        // GET: MiscItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItem = await _context.MiscItem.FindAsync(id);
            if (miscItem == null)
            {
                return NotFound();
            }
            return View(miscItem);
        }

        // POST: MiscItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,requested,ResCleanDetailId,MiscItemTypeId")] MiscItem miscItem)
        {
            if (id != miscItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miscItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiscItemExists(miscItem.Id))
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
            return View(miscItem);
        }

        // GET: MiscItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItem = await _context.MiscItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miscItem == null)
            {
                return NotFound();
            }

            return View(miscItem);
        }

        // POST: MiscItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miscItem = await _context.MiscItem.FindAsync(id);
            if (miscItem != null)
            {
                _context.MiscItem.Remove(miscItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiscItemExists(int id)
        {
            return _context.MiscItem.Any(e => e.Id == id);
        }
    }
}
