using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Authorization;

namespace Honeymoonshop.Controllers
{
    [Authorize]
    public class KleurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KleurController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Kleur
        
        public IActionResult Index()
        {
            return View( _context.Kleuren.ToList());
        }

        // GET: Kleur/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur =  _context.Kleuren.SingleOrDefault(m => m.Id == id);
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
        public IActionResult Create([Bind("Naam,KleurCode")] Kleur kleur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kleur);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kleur);
        }

        // GET: Kleur/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = _context.Kleuren.SingleOrDefault(m => m.Id == id);
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
        public IActionResult Edit(int id, [Bind("Id,Naam,KleurCode")] Kleur kleur)
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
                    _context.SaveChanges();
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kleur = _context.Kleuren.SingleOrDefault(m => m.Id == id);
            if (kleur == null)
            {
                return NotFound();
            }

            return View(kleur);
        }

        // POST: Kleur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kleur = _context.Kleuren.SingleOrDefault(m => m.Id == id);
            //verwijder eerst de afbeeldingen die gekoppeld zijn aan deze kleur
            _context.ProductAfbeeldingen.RemoveRange(_context.ProductAfbeeldingen.Where(x => x.Kleurproduct.KleurId == id).ToList());
            //Verwijder daarna de relatie tussen de kleur en de producten die bij deze kleur horen.
            _context.ktKleurProduct.RemoveRange(_context.ktKleurProduct.Where(x => x.KleurId == id ).ToList());
            //Verwijder daarna de kleur
            _context.Kleuren.Remove(kleur);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool KleurExists(int id)
        {
            return _context.Kleuren.Any(e => e.Id == id);
        }
    }
}
