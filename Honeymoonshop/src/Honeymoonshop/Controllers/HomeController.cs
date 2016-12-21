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
            var hetProduct = Context.Producten.Include(x => x.kleuren).ThenInclude(x => x.kleur).Include(x => x.categorie).Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).FirstOrDefault(product => product.id == id);
            var hetMerk = Context.Merken.FirstOrDefault(merk => merk.id == hetProduct.merkId);
            hetProduct.merk = hetMerk;
            ViewData["Product"] = hetProduct;

            return View();
        }

    }
}
