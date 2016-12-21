using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Models.FilterViewModels;

namespace Honeymoonshop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context;

        public HomeController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        
        public IActionResult Dressfinder()
        {
            var producten = Context.Producten.Include(x => x.merk).ToList();
            //  .Select(p => p.Merk);
           /* var producten = Context.Producten;
            List<Product> deProducten = new List<Product>();
           /* foreach (Product product in producten)
            {
                var hetMerk = Context.Merken.FirstOrDefault(merk => merk.id == product.merkId);
                product.merk = hetMerk;
                deProducten.Add(product);
            }*/ 

            return View(producten);
        }

        [HttpPost]
        public IActionResult Dressfinder(FilterProduct filterproduct)
        {

            /*var priceOut = 10000;
            int.TryParse(filterproduct.priceInputName, out priceOut);
            var producten = Context.Producten.Include(x => x.merk).ToList().FindAll(x => x.prijs <= priceOut);*/

            //var producten = Context.Producten.Where(x => x.prijs < filterproduct.maxPrijs && x.prijs > filterproduct.minPrijs ).Include(x => x.merk).ToList();
            var producten = Context.Producten.Include(x => x.merk).Where(x => x.prijs < filterproduct.minPrijs && x.prijs < filterproduct.maxPrijs).ToList();
            return View(producten);
        }   


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Catalogus()
        {
            return View();
        }

        public IActionResult ProductPagina(int id)
        {
            //Rewritten na images met kleur zijn gekoppeld
            var hetProduct = Context.ktKleurProduct.Include(k => k.kleur).Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.product.kleuren).Include(c => c.product.categorie).Include(x => x.images).FirstOrDefault(kleurproduct => kleurproduct.productId == id);
            List<Product> gerelateerdeProducten = new List<Product>();

            var gerelateerdProduct = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Take(4).Where(kleurproduct => kleurproduct.product.categorieId == hetProduct.product.categorieId);


            /*//Oud
            var hetProduct = Context.Producten.Include(mrk => mrk.merk).Include(x => x.kleuren).ThenInclude(x => x.kleur).Include(x => x.categorie).Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).Include(img => img.afbeeldingen).FirstOrDefault(product => product.id == id);
            //var hetMerk = Context.Merken.FirstOrDefault(merk => merk.id == hetProduct.merkId);
            //hetProduct.merk = hetMerk;
            List<ProductImage> productAfbeeldingen = new List<ProductImage>();
            List<Product> gerelateerdeProducten = new List<Product>();
            int i = 0;


            foreach (Product p in Context.Producten)
            {
                if (i < 4)
                {
                    p.merk = Context.Merken.FirstOrDefault(merk => merk.id == p.merkId);
                    var afb = Context.ProductAfbeeldingen.Include(prodimg => prodimg.product).FirstOrDefault(img => img.product.id == p.id);
                    List<ProductImage> afbLijst = new List<ProductImage>();
                    afbLijst.Add(afb);
                    p.afbeeldingen = afbLijst;
                    gerelateerdeProducten.Add(p);
                    i++;
                }
                else
                {
                    break;
                }
            }*/
            ViewData["gerelateerdeProducten"] = gerelateerdeProducten;
            ViewData["Product"] = hetProduct;

            return View();
        }

    }
}
