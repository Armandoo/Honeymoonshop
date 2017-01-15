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

        /*[HttpPost]
        public IActionResult Dressfinder(FilterProduct filterproduct)
        {

            var producten = Context.Producten.ToList();
            var categorieen = Context.Category.ToList();
            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            return View(producten);

            /*var priceOut = 10000;
            int.TryParse(filterproduct.priceInputName, out priceOut);
            var producten = Context.Producten.Include(x => x.merk).ToList().FindAll(x => x.prijs <= priceOut);*/

            //var producten = Context.Producten.Where(x => x.prijs < filterproduct.maxPrijs && x.prijs > filterproduct.minPrijs ).Include(x => x.merk).ToList();
            //
            //var categorieen = Context.Category.ToList();
            /**if (filterproduct.actieveCategorieen != 0)
            {
                producten.FindAll(x => x.categorie.id == filterproduct.actieveCategorieen);
            }*/
            
            
            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            //return View(new FilterProduct()
            //{
            //    producten = producten.ToList(),
            //    merken = merken,
            //    silhouette = kenmerkSilhouette,
            //    neklijn = kenmerkNeklijn,
            //    kleuren = kleur,
            //    categorieen = categorieen
            //});
      //  }   


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
    }
}
