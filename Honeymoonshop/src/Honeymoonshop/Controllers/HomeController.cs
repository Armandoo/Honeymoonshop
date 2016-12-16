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
