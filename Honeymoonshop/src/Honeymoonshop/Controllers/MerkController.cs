using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Data;
using Honeymoonshop.Models;

namespace Honeymoonshop.Controllers
{
    public class MerkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerkController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Merk
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merken.ToListAsync());
        }

        // GET: Merk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.Id == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // GET: Merk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MerkNaam")] Merk merk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(merk);
        }

        // GET: Merk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.Id == id);
            if (merk == null)
            {
                return NotFound();
            }
            return View(merk);
        }

        // POST: Merk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MerkNaam")] Merk merk)
        {
            if (id != merk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkExists(merk.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(merk);
        }

        // GET: Merk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.Id == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // POST: Merk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.Id == id);
            _context.Merken.Remove(merk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MerkExists(int id)
        {
            return _context.Merken.Any(e => e.Id == id);
        }
    }
}
