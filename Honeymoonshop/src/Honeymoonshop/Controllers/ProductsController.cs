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
            List<Kleurproduct> hetProduct = _context.ktKleurProduct.Include(k => k.kleur).Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.product.kleuren).ThenInclude(c => c.kleur).Include(c => c.product.categorie).Include(x => x.images).Include(x => x.product.kenmerken).ThenInclude(x => x.kenmerk).Where(kleurproduct => kleurproduct.productId == id).ToList();
            ViewData["kleurenMetProduct"] = hetProduct;
            return View(hetProduct);
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
                return RedirectToAction("Images", id);
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

            if (ModelState.IsValid && kleur.Length > 0 && kenmerk.Length > 0)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Images", new { id = product.id});
            }
            
            return View(new CreateProduct()
            {
                Categorieen = new SelectList(_context.Category, "id", "naam", product.categorieId),
                Merken = new SelectList(_context.Merken, "id", "merkNaam", product.merkId),
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
        public async Task<IActionResult> Edit(int id, [Bind("id,artikelnummer,geslacht,categorieId,merkId,omschrijving,prijs")] Product product, string[] kleuren, string[] kenmerk)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Kleuren
                var kleurProducten = new List<Kleurproduct>();
                List<Kleurproduct> huidigeKleurenVanProduct = _context.ktKleurProduct.Include(x => x.kleur).Where(x => x.productId == id).ToList();
                List<int> idVanHuidigeKleuren = new List<int>();
                foreach (Kleurproduct kleur in huidigeKleurenVanProduct)
                {
                    idVanHuidigeKleuren.Add(kleur.kleurId);
                }
                List<int> kleurenIds = new List<int>();
                var kleurId = 0;
                foreach (var kleur in kleuren)
                {
                    if (int.TryParse(kleur, out kleurId))
                        kleurenIds.Add(kleurId);
                }

                IEnumerable<int> overeenkomsten = kleurenIds.Intersect(idVanHuidigeKleuren);//Bepaal de overeenkomsten tussen de aangevinkte kleuren van het formulier en de kleuren die opgeslagen waren in de database
                //Bestaande kleuren toevoegen aan het object
                foreach (int overeenkomendId in overeenkomsten)
                {
                    //Komt overeen met een kleur van het product
                    kleurProducten.Add(_context.ktKleurProduct.Include(x => x.kleur).Where(x => x.productId == product.id && x.kleur == _context.Kleuren.Where(kl => kl.id == overeenkomendId).Single()).SingleOrDefault());
                }

                IEnumerable<int> nieuweKleuren = kleurenIds.Except(idVanHuidigeKleuren);//Bepaal welke van de aangevinkte kleuren nog niet een relatie hadden met een product
                foreach (int nieuweKleurId in nieuweKleuren)
                {
                    //Nieuwe kleuren in de aangevinkte kleuren die nog niet zijn toegewezen aan het product.
                    kleurProducten.Add(new Kleurproduct() { kleur = _context.Kleuren.Where(x => x.id == nieuweKleurId).SingleOrDefault() });
                }

                IEnumerable<int> verschillen = idVanHuidigeKleuren.Except(kleurenIds);//Bepaal welke kleuren die een relatie hebben met product niet meer aangevinkt zijn.
                foreach (int teVerwijderenId in verschillen)
                {
                    //Deze kleuren zijn niet aangevinkt.
                    //Verwijder de relatie met afbeelding
                    _context.ProductAfbeeldingen.Remove(_context.ProductAfbeeldingen.Where(x => x.kleurproduct.kleurId == teVerwijderenId && x.kleurproduct.productId == id).FirstOrDefault());
                    //Verwijder daarna de relatie tussen kleur en product
                    _context.ktKleurProduct.Remove(_context.ktKleurProduct.Where(kleurproduct => kleurproduct.productId == id && kleurproduct.kleurId == teVerwijderenId).FirstOrDefault());
                }
                product.kleuren = kleurProducten;
                //Kenmerken
                List<int> kenmerkenIds = new List<int>();
                foreach (string knmrk in kenmerk)
                {
                    int kenmerkId = 0;
                    if (int.TryParse(knmrk, out kenmerkId))
                    {
                        kenmerkenIds.Add(kenmerkId);
                    }
                }
                var kenmerkenVanProduct = _context.KenmerkProduct.Where(x => x.productId == id);
                List<int> kenmerkenIdsVanProduct = new List<int>();
                foreach (Kenmerkproduct kp in kenmerkenVanProduct)
                {
                    kenmerkenIdsVanProduct.Add(kp.kenmerkId);
                }
                var kenmerkenVerschillen = kenmerkenIdsVanProduct.Except(kenmerkenIds);//Bepaalt welke kenmerken wel in product zitten, maar nu niet meer aangevinkt zijn
                var nieuweKenmerken = kenmerkenIds.Except(kenmerkenIdsVanProduct);//Bepaalt welke kenmerken niet in product zitten, maar wel aangevinkt zijn
                List<Kenmerkproduct> kenmerkenOmOpTeSlaan = new List<Kenmerkproduct>();//Lijst die wordt gevuld met de kenmerken die worden opgeslagen
                foreach (int teVerwijderenKenmerk in kenmerkenVerschillen)
                {
                    _context.KenmerkProduct.Remove(_context.KenmerkProduct.Where(x => x.kenmerkId == teVerwijderenKenmerk && x.productId == id).First());
                }
                _context.SaveChanges();
                foreach (int toeTeVoegenKenmerken in nieuweKenmerken)
                {
                    kenmerkenOmOpTeSlaan.Add(new Kenmerkproduct() { kenmerk = _context.Kenmerken.Where(x => x.id == toeTeVoegenKenmerken).First(),kenmerkId = toeTeVoegenKenmerken, productId = id});
                }
                _context.KenmerkProduct.AddRange(kenmerkenOmOpTeSlaan);
                
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
        /*
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.SingleOrDefaultAsync(m => m.id == id);
            List<ProductImage> teVerwijderenImages = _context.ProductAfbeeldingen.Include(x => x.kleurproduct).ToList().FindAll(x => x.kleurproduct.productId == id);
            List<Kleurproduct> teVerwijderenKleuren = _context.ktKleurProduct.ToList().FindAll(x => x.productId == id);
            _context.ProductAfbeeldingen.RemoveRange(teVerwijderenImages);
            _context.ktKleurProduct.RemoveRange(teVerwijderenKleuren);
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
