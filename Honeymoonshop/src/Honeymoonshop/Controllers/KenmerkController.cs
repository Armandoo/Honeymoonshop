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
    public class KenmerkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KenmerkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kenmerk
        public IActionResult Index()
        {
            return View(_context.Kenmerken.ToList());
        }

        // GET: Kenmerk/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kenmerk = _context.Kenmerken.SingleOrDefault(m => m.Id == id);
            if (kenmerk == null)
            {
                return NotFound();
            }

            return View(kenmerk);
        }

        // GET: Kenmerk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kenmerk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naam,KenmerkType")] Kenmerk kenmerk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kenmerk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kenmerk);
        }

        // GET: Kenmerk/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kenmerk = _context.Kenmerken.SingleOrDefault(m => m.Id == id);
            if (kenmerk == null)
            {
                return NotFound();
            }
            return View(kenmerk);
        }

        // POST: Kenmerk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Naam,KenmerkType")] Kenmerk kenmerk)
        {
            if (id != kenmerk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kenmerk);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KenmerkExists(kenmerk.Id))
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
            return View(kenmerk);
        }

        // GET: Kenmerk/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kenmerk = _context.Kenmerken.SingleOrDefault(m => m.Id == id);
            if (kenmerk == null)
            {
                return NotFound();
            }

            return View(kenmerk);
        }

        // POST: Kenmerk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kenmerk = _context.Kenmerken.SingleOrDefault(m => m.Id == id);
            _context.Kenmerken.Remove(kenmerk);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool KenmerkExists(int id)
        {   
            return _context.Kenmerken.Any(e => e.Id == id);
        }
    }
}
