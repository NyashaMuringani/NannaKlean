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
    public class MiscItemTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiscItemTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MiscItemTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiscItemType.ToListAsync());
        }

        // GET: MiscItemTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItemType = await _context.MiscItemType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miscItemType == null)
            {
                return NotFound();
            }

            return View(miscItemType);
        }

        // GET: MiscItemTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiscItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,shortDesc,longDesc,requested")] MiscItemType miscItemType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miscItemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miscItemType);
        }

        // GET: MiscItemTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItemType = await _context.MiscItemType.FindAsync(id);
            if (miscItemType == null)
            {
                return NotFound();
            }
            return View(miscItemType);
        }

        // POST: MiscItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,shortDesc,longDesc,requested")] MiscItemType miscItemType)
        {
            if (id != miscItemType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miscItemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiscItemTypeExists(miscItemType.Id))
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
            return View(miscItemType);
        }

        // GET: MiscItemTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miscItemType = await _context.MiscItemType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miscItemType == null)
            {
                return NotFound();
            }

            return View(miscItemType);
        }

        // POST: MiscItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miscItemType = await _context.MiscItemType.FindAsync(id);
            if (miscItemType != null)
            {
                _context.MiscItemType.Remove(miscItemType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiscItemTypeExists(int id)
        {
            return _context.MiscItemType.Any(e => e.Id == id);
        }
    }
}
