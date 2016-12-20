using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop.Data;
using Microsoft.AspNetCore.Mvc;
using Honeymoonshop.Models;
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

        public IActionResult ProductPagina()
        {
            return View();
        }

    }
}
