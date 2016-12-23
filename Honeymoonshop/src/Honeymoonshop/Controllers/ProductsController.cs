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

            var product = await _context.Producten.Include(x => x.merk)
                .Include(x => x.categorie)
                .Include(x => x.kenmerken).ThenInclude(x => x.kenmerk)
                .Include(x => x.kleuren).ThenInclude(x => x.kleur)
                .SingleOrDefaultAsync(m => m.id == id);
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
        public async Task<IActionResult> Create([Bind("id,artikelnummer,geslacht,categorieId,merkId,omschrijving,prijs")] Product product, string[] kleur, string[] kenmerk)
        {
            if (kleur != null)
            {
                product.kleuren = new List<Kleurproduct>();
                foreach (var k in kleur)
                {
                    var kleurId = 0;
                    int.TryParse(k, out kleurId);
                    product.kleuren.Add(new Kleurproduct() { kleur = _context.Kleuren.ToList().Find(x => x.id == kleurId) });
                }
            }

            if (kenmerk != null)
            {
                product.kenmerken = new List<Kenmerkproduct>();
                foreach (var k in kenmerk)
                {
                    var kenmerkId = 0;
                    int.TryParse(k, out kenmerkId);
                    product.kenmerken.Add(new Kenmerkproduct() { kenmerk = _context.Kenmerken.ToList().Find(x => x.id == kenmerkId) });

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
                Categorieen = new SelectList(_context.Category, "id", "naam", product.categorie),
                Merken = new SelectList(_context.Merken, "id", "merkNaam", product.merk.id),
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

            var product = _context.Producten.Include(x => x.kleuren).ThenInclude(x => x.kleur)
                           .Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).SingleOrDefault(x => x.id == id);
            if (product == null)
            {
                return NotFound();
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

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,artikelnummer,geslacht,categorieId,merkId,omschrijving,prijs")] Product product, string[] kleur, string[] kenmerk)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // var kt = new List<Kleurproduct>();
                //foreach(var k in kleur)
                // {
                //     var kid = 0;
                //     Kleurproduct kp = null;
                //     if(int.TryParse(k, out kid))
                //     {
                //         kp = _context.ktKleurProduct.Include(x => x.kleur).Where(x => x.productId == product.id && x.kleur == _context.Kleuren.Where(kl => kl.id == kid).Single()).SingleOrDefault();
                //         if (kp != null)
                //         {
                //             kt.Add(kp);
                //         }else
                //         {
                //             kt.Add(new Kleurproduct() { kleur = _context.Kleuren.Where(x => x.id == kid).SingleOrDefault()});
                //         }

                //     }
                //}
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
