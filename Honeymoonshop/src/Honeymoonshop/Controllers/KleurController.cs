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
    public class KleurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KleurController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Kleur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kleuren.ToListAsync());
        }

        // GET: Kleur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleuren.SingleOrDefaultAsync(m => m.Id == id);
            if (kleur == null)
            {
                return NotFound();
            }

            return View(kleur);
        }

        // GET: Kleur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kleur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,KleurCode")] Kleur kleur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kleur);
        }

        // GET: Kleur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleuren.SingleOrDefaultAsync(m => m.Id == id);
            if (kleur == null)
            {
                return NotFound();
            }
            return View(kleur);
        }

        // POST: Kleur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] Kleur kleur)
        {
            if (id != kleur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kleur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KleurExists(kleur.Id))
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
            return View(kleur);
        }

        // GET: Kleur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = await _context.Kleuren.SingleOrDefaultAsync(m => m.Id == id);
            if (kleur == null)
            {
                return NotFound();
            }

            return View(kleur);
        }

        // POST: Kleur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kleur = await _context.Kleuren.SingleOrDefaultAsync(m => m.Id == id);
            _context.Kleuren.Remove(kleur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KleurExists(int id)
        {
            return _context.Kleuren.Any(e => e.Id == id);
        }
    }
}
