using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var producten = Context.Producten.Include(x => x.merk);
            //  .Select(p => p.Merk);
           /* var producten = Context.Producten;
            List<Product> deProducten = new List<Product>();
           /* foreach (Product product in producten)
            {
                var hetMerk = Context.Merken.FirstOrDefault(merk => merk.id == product.merkId);
                product.merk = hetMerk;
                deProducten.Add(product);
            }*/
            return View(producten.ToList());
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
            var hetProduct = Context.ktKleurProduct.Include(k => k.kleur).Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.product.kleuren).Include(c => c.product.categorie).Include(x => x.images).Include(x => x.product.kenmerken).ThenInclude(x => x.kenmerk).FirstOrDefault(kleurproduct => kleurproduct.productId == id);
            var gerelateerdeProducten = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Take(4).Where(kleurproduct => kleurproduct.product.categorieId == hetProduct.product.categorieId && kleurproduct.productId != id).ToList();
            var accessoires = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Take(4).Where(kleurproduct => kleurproduct.kleurId == hetProduct.kleurId && kleurproduct.product.categorie.isAccessoire == true).ToList();
            ViewData["gerelateerdeProducten"] = gerelateerdeProducten;
            ViewData["Product"] = hetProduct;
            ViewData["Accessoires"] = accessoires;
            return View();
        }
    }
}
