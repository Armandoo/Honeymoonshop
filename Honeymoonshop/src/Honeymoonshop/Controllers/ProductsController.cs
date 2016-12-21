using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Honeymoonshop.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Honeymoonshop.Models.Utils;

namespace Honeymoonshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Producten.Include(p => p.categorie).Include(p => p.merk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View(new CreateProduct() {
                Categorieen = new SelectList(_context.Category, "id", "naam"),
                Merken = new SelectList(_context.Merken, "id", "merkNaam"),
                Kenmerken =  _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                product = new Product()
                

            });
        }

        [HttpGet]
        public IActionResult Images(int id)
        {
            var product =_context.Producten.Include(p => p.kleuren).ThenInclude(x => x.kleur).SingleOrDefault(p => p.id == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Images(int id, int kid,  IFormFile[] afbeeldingen)
        {
            var product = _context.Producten.Include(p => p.kleuren).ThenInclude(l => l.kleur).Include(f => f.kleuren).SingleOrDefault(p => p.id == id);
            var kleur = _context.Kleuren.SingleOrDefault(k => k.id == kid);

            var x = FileUploader<ProductImage>.UploadImages(afbeeldingen);

            var kp = _context.ktKleurProduct.ToList().Find(f => f.kleur == kleur && f.productId == product.id);
            kp.images = x;
            product.kleuren.Add(kp);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            return View(product);
        }


        //refactoren
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,artikelnummer,categorieId,merkId,omschrijving,prijs")] Product product, string[] kleur, string[] kenmerk, IFormFile[] afbeeldingen)
        {
            if (kleur!=null)
            {
                product.kleuren = new List<Kleurproduct>();
                foreach(var k in kleur)
                {
                    var kleurId = 0;
                    if (int.TryParse(k,out kleurId))
                    {
                        product.kleuren.Add(new Kleurproduct() { kleurId = kleurId });
                    }
                }
            }

            if (kenmerk != null)
            {
                product.kenmerken = new List<Kenmerkproduct>();
                foreach (var k in kenmerk)
                {
                    var kenmerkId = 0;
                    if (int.TryParse(k, out kenmerkId))
                    {
                        product.kenmerken.Add(new Kenmerkproduct() { kenmerkId = kenmerkId });
                    }
                }
            }

           
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(new CreateProduct()
            {
                Categorieen = new SelectList(_context.Category, "id", "naam"),
                Merken = new SelectList(_context.Merken, "id", "merkNaam"),
                Kenmerken = _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                product = product


            });
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categorieId"] = new SelectList(_context.Category, "id", "id", product.categorieId);
            ViewData["merkId"] = new SelectList(_context.Merken, "id", "id", product.merkId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,artikelnummer,categorieId,merkId,omschrijving,prijs")] Product product, string[] kleur, string[] kenmerk, IFormFile[] afbeeldingen)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (kleur != null)
            {
                product.kleuren = new List<Kleurproduct>();
                foreach (var k in kleur)
                {
                    var kleurId = 0;
                    if (int.TryParse(k, out kleurId))
                    {
                        product.kleuren.Add(new Kleurproduct() { kleurId = kleurId });
                    }
                }
            }

            if (kenmerk != null)
            {
                product.kenmerken = new List<Kenmerkproduct>();
                foreach (var k in kenmerk)
                {
                    var kenmerkId = 0;
                    if (int.TryParse(k, out kenmerkId))
                    {
                        product.kenmerken.Add(new Kenmerkproduct() { kenmerkId = kenmerkId });
                    }
                }
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            return View(new CreateProduct()
            {
                Categorieen = new SelectList(_context.Category, "id", "naam"),
                Merken = new SelectList(_context.Merken, "id", "merkNaam"),
                Kenmerken = _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                product = product


            });
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.id == id);
        }
    }
}
