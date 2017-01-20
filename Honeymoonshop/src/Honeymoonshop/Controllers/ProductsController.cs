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
using Microsoft.AspNetCore.Authorization;

namespace Honeymoonshop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Products
        public IActionResult Index()
        {
            var applicationDbContext = _context.Producten.Include(p => p.Categorie).Include(p => p.Merk);
            return View(applicationDbContext.ToList());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Producten.Include(x => x.Merk)
                .Include(x => x.Categorie)
                .Include(x => x.Kenmerken).ThenInclude(x => x.Kenmerk)
                .Include(x => x.Kleuren).ThenInclude(x => x.Kleur)
                .SingleOrDefault(m => m.Id == id);
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
                Categorieen = new SelectList(_context.Category, "Id", "Naam"),
                Merken = new SelectList(_context.Merken, "Id", "MerkNaam"),
                Kenmerken =  _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                Product = new Product()

                

            });
        }

        [HttpGet]
        public IActionResult Images(int id)
        {
            List<Kleurproduct> hetProduct = _context.ktKleurProduct.Include(k => k.Kleur).Include(x => x.Product).ThenInclude(x => x.Merk).Include(x => x.Product.Kleuren).ThenInclude(c => c.Kleur).Include(c => c.Product.Categorie).Include(x => x.Images).Include(x => x.Product.Kenmerken).ThenInclude(x => x.Kenmerk).Where(kleurproduct => kleurproduct.ProductId == id).ToList();
            ViewData["kleurenMetProduct"] = hetProduct;
            return View(hetProduct);
        }

        [HttpPost]
        public IActionResult Images(int id, int kid,  IFormFile[] afbeeldingen)
        {
            var product = _context.Producten.Include(p => p.Kleuren).ThenInclude(l => l.Kleur).Include(f => f.Kleuren).SingleOrDefault(p => p.Id == id);
            var kleur = _context.Kleuren.SingleOrDefault(k => k.Id == kid);

            var x = FileUploader<ProductImage>.UploadImages(afbeeldingen);

            var kp = _context.ktKleurProduct.ToList().Find(f => f.Kleur == kleur && f.ProductId == product.Id);
            kp.Images = x;
            product.Kleuren.Add(kp);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
        public IActionResult Create([Bind("Id,Artikelnummer,Geslacht,CategorieId,MerkId,Omschrijving,Prijs")] Product product, string[] kleur, string[] kenmerk)
        {
            if (kleur != null)
            {
                product.Kleuren = new List<Kleurproduct>();
                foreach (var k in kleur)
                {
                    var kleurId = 0;
                    int.TryParse(k, out kleurId);
                    product.Kleuren.Add(new Kleurproduct() { Kleur = _context.Kleuren.ToList().Find(x => x.Id == kleurId) });
                }
            }

            if (kenmerk != null)
            {
                product.Kenmerken = new List<Kenmerkproduct>();
                foreach (var k in kenmerk)
                {
                    var kenmerkId = 0;
                    int.TryParse(k, out kenmerkId);
                    product.Kenmerken.Add(new Kenmerkproduct() { Kenmerk = _context.Kenmerken.ToList().Find(x => x.Id == kenmerkId) });

                }
            }

            if (ModelState.IsValid && kleur.Length > 0 && kenmerk.Length > 0)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Images", new { id = product.Id });
            }
            
            return View(new CreateProduct()
            {
                Categorieen = new SelectList(_context.Category, "Id", "Naam", product.CategorieId),
                Merken = new SelectList(_context.Merken, "Id", "MerkNaam", product.MerkId),
                Kenmerken = _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                Product = product

            });
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Producten.Include(x => x.Kleuren).ThenInclude(x => x.Kleur)
                           .Include(x => x.Kenmerken).ThenInclude(x => x.Kenmerk).SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new CreateProduct()
            {
                Categorieen = new SelectList(_context.Category, "Id", "Naam"),
                Merken = new SelectList(_context.Merken, "Id", "MerkNaam"),
                Kenmerken = _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                Product = product
            });
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Artikelnummer,Geslacht,CategorieId,MerkId,Omschrijving,Prijs")] Product product, string[] kleuren, string[] kenmerk)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Kleuren
                var kleurProducten = new List<Kleurproduct>();
                List<Kleurproduct> huidigeKleurenVanProduct = _context.ktKleurProduct.Include(x => x.Kleur).Where(x => x.ProductId == id).ToList();
                List<int> idVanHuidigeKleuren = new List<int>();
                foreach (Kleurproduct kleur in huidigeKleurenVanProduct)
                {
                    idVanHuidigeKleuren.Add(kleur.KleurId);
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
                    kleurProducten.Add(_context.ktKleurProduct.Include(x => x.Kleur).Where(x => x.ProductId == product.Id && x.Kleur == _context.Kleuren.Where(kl => kl.Id == overeenkomendId).Single()).SingleOrDefault());
                }

                IEnumerable<int> nieuweKleuren = kleurenIds.Except(idVanHuidigeKleuren);//Bepaal welke van de aangevinkte kleuren nog niet een relatie hadden met een product
                foreach (int nieuweKleurId in nieuweKleuren)
                {
                    //Nieuwe kleuren in de aangevinkte kleuren die nog niet zijn toegewezen aan het product.
                    kleurProducten.Add(new Kleurproduct() { Kleur = _context.Kleuren.Where(x => x.Id == nieuweKleurId).SingleOrDefault() });
                }

                IEnumerable<int> verschillen = idVanHuidigeKleuren.Except(kleurenIds);//Bepaal welke kleuren die een relatie hebben met product niet meer aangevinkt zijn.
                foreach (int teVerwijderenId in verschillen)
                {
                    //Deze kleuren zijn niet aangevinkt.
                    //Verwijder de relatie met afbeelding
                    _context.ProductAfbeeldingen.Remove(_context.ProductAfbeeldingen.Where(x => x.Kleurproduct.KleurId == teVerwijderenId && x.Kleurproduct.ProductId == id).FirstOrDefault());
                    //Verwijder daarna de relatie tussen kleur en product
                    _context.ktKleurProduct.Remove(_context.ktKleurProduct.Where(kleurproduct => kleurproduct.ProductId == id && kleurproduct.KleurId == teVerwijderenId).FirstOrDefault());
                }
                product.Kleuren = kleurProducten;
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
                var kenmerkenVanProduct = _context.KenmerkProduct.Where(x => x.ProductId == id);
                List<int> kenmerkenIdsVanProduct = new List<int>();
                foreach (Kenmerkproduct kp in kenmerkenVanProduct)
                {
                    kenmerkenIdsVanProduct.Add(kp.KenmerkId);
                }
                var kenmerkenVerschillen = kenmerkenIdsVanProduct.Except(kenmerkenIds);//Bepaalt welke kenmerken wel in product zitten, maar nu niet meer aangevinkt zijn
                var nieuweKenmerken = kenmerkenIds.Except(kenmerkenIdsVanProduct);//Bepaalt welke kenmerken niet in product zitten, maar wel aangevinkt zijn
                List<Kenmerkproduct> kenmerkenOmOpTeSlaan = new List<Kenmerkproduct>();//Lijst die wordt gevuld met de kenmerken die worden opgeslagen
                foreach (int teVerwijderenKenmerk in kenmerkenVerschillen)
                {
                    _context.KenmerkProduct.Remove(_context.KenmerkProduct.Where(x => x.KenmerkId == teVerwijderenKenmerk && x.ProductId == id).First());
                }
                _context.SaveChanges();
                foreach (int toeTeVoegenKenmerken in nieuweKenmerken)
                {
                    kenmerkenOmOpTeSlaan.Add(new Kenmerkproduct() { Kenmerk = _context.Kenmerken.Where(x => x.Id == toeTeVoegenKenmerken).First(),KenmerkId = toeTeVoegenKenmerken, ProductId = id});
                }
                _context.KenmerkProduct.AddRange(kenmerkenOmOpTeSlaan);
                
                try
                {
                    _context.Update(product);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
                Categorieen = new SelectList(_context.Category, "Id", "Naam", product.CategorieId),
                Merken = new SelectList(_context.Merken, "Id", "MerkNaam", product.MerkId),
                Kenmerken = _context.Kenmerken.ToList(),
                Kleuren = _context.Kleuren.ToList(),
                Product = product
            });
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Producten.SingleOrDefault(m => m.Id == id);
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
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Producten.SingleOrDefault(m => m.Id == id);
            List<ProductImage> teVerwijderenImages = _context.ProductAfbeeldingen.Include(x => x.Kleurproduct).ToList().FindAll(x => x.Kleurproduct.ProductId == id);
            List<Kleurproduct> teVerwijderenKleuren = _context.ktKleurProduct.ToList().FindAll(x => x.ProductId == id);
            _context.ProductAfbeeldingen.RemoveRange(teVerwijderenImages);
            _context.ktKleurProduct.RemoveRange(teVerwijderenKleuren);
            _context.Producten.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.Id == id);
        }
    }
}
