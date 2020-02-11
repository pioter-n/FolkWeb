using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Role.Areas.DancesType.Models;
using Role.Data;

namespace Role.Areas.DanceType.Controllers
{
    [Area("DanceType")]
    public class DanceTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanceTypesController(ApplicationDbContext context)
        {
            //
            _context = context;
        }

        // GET: DanceType/DanceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanceTypes.ToListAsync());
        }

        // GET: DanceType/DanceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceTypes = await _context.DanceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danceTypes == null)
            {
                return NotFound();
            }

            return View(danceTypes);
        }

        // GET: DanceType/DanceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanceType/DanceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Types")] DanceTypes danceTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danceTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danceTypes);
        }

        // GET: DanceType/DanceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceTypes = await _context.DanceTypes.FindAsync(id);
            if (danceTypes == null)
            {
                return NotFound();
            }
            return View(danceTypes);
        }

        // POST: DanceType/DanceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Types")] DanceTypes danceTypes)
        {
            if (id != danceTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danceTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceTypesExists(danceTypes.Id))
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
            return View(danceTypes);
        }

        // GET: DanceType/DanceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceTypes = await _context.DanceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danceTypes == null)
            {
                return NotFound();
            }

            return View(danceTypes);
        }

        // POST: DanceType/DanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danceTypes = await _context.DanceTypes.FindAsync(id);
            _context.DanceTypes.Remove(danceTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceTypesExists(int id)
        {
            return _context.DanceTypes.Any(e => e.Id == id);
        }
    }
}
