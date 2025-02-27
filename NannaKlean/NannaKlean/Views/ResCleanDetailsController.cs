using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NannaKlean.Data;
using NannaKlean.Models;
using NuGet.Protocol;

namespace NannaKlean.Views
{
    public class ResCleanDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResCleanDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResCleanDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResCleanDetail.ToListAsync());
        }

        // GET: ResCleanDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //get the resCleanDetail
            var resCleanDetail = await _context.ResCleanDetail
                .FirstOrDefaultAsync(m => m.Id == id);

            //get the list of miscItems
            List<MiscItem> miscItemsList = (from selectMiscItem in _context.MiscItem
                                 where selectMiscItem.ResCleanDetailId == id
                                 select selectMiscItem).ToList();

            //fill in each misc item with its misc item type
            foreach (MiscItem miscItem in miscItemsList)
             {
                List<MiscItemType> itemType = (from selectMiscItemType in _context.MiscItemType
                                         where selectMiscItemType.Id == miscItem.MiscItemTypeId
                                         select selectMiscItemType).ToList();

                if (itemType.Count > 0)
                    {
                    miscItem.MiscItemType = itemType[0];
                }
            }

            //var miscItemsList = (from selectMiscItem in _context.MiscItem
            //                      join selectMiscItemType in _context.MiscItemType on selectMiscItem.MiscItemTypeId equals selectMiscItemType.Id where selectMiscItem.ResCleanDetailId == id
            //                      select selectMiscItem).ToList();

                //var dealercontacts2 = (from selectMiscItem in _context.MiscItem
                //                      join selectMiscItemType in _context.MiscItemType on selectMiscItem.MiscItemTypeId equals selectMiscItemType.Id
                //                      select new { selectMiscItemType.longDesc,selectMiscItem.requested }).ToList();

            if (resCleanDetail == null)
            {
                return NotFound();
            }

foreach (MiscItem miscItem in miscItemsList)
                {
                resCleanDetail.miscItems.Add(miscItem);
            }

                return View(resCleanDetail);
        }

        // GET: ResCleanDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResCleanDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,squareFeet,numLivingRooms,numBedrooms,numBathRooms,createTime")] ResCleanDetail resCleanDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resCleanDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateCustom", "MiscItems");
            }
            return View(resCleanDetail);
        }

        // GET: ResCleanDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resCleanDetail = await _context.ResCleanDetail.FindAsync(id);
            if (resCleanDetail == null)
            {
                return NotFound();
            }
            return View(resCleanDetail);
        }

        // POST: ResCleanDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,squareFeet,numLivingRooms,numBedrooms,numBathRooms,createTime")] ResCleanDetail resCleanDetail)
        {
            if (id != resCleanDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resCleanDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResCleanDetailExists(resCleanDetail.Id))
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
            return View(resCleanDetail);
        }

        // GET: ResCleanDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resCleanDetail = await _context.ResCleanDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resCleanDetail == null)
            {
                return NotFound();
            }

            return View(resCleanDetail);
        }

        // POST: ResCleanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resCleanDetail = await _context.ResCleanDetail.FindAsync(id);
            if (resCleanDetail != null)
            {
                _context.ResCleanDetail.Remove(resCleanDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResCleanDetailExists(int id)
        {
            return _context.ResCleanDetail.Any(e => e.Id == id);
        }
    }
}
