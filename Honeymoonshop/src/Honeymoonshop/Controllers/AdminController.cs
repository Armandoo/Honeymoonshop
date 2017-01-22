using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Honeymoonshop.Models;
using Honeymoonshop.Data;

namespace Honeymoonshop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext Context;

        public AdminController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*
        public IActionResult Categorie() {
            return View();
        }

        public IActionResult ProductToevoegen()
        {
            ViewData["Message"] = "Trouwjurken";

            return View();
        }
        
        [HttpPost]
        public IActionResult ProductToevoegen(Product p)
        {
            Context.Producten.Add(p);
            Context.SaveChanges();
            return View();
        }

        public IActionResult PakToevoegen()
        {
            ViewData["Message"] = "Pakken";

            return View();
        }

        public IActionResult AccesoireToevoegen()
        {
            ViewData["Message"] = "Accesoires";

            return View();
        }

        public IActionResult ProductOverzicht()
        {
            return View(new List<Product>());
        }

        public IActionResult CategorieOverzicht()
        {
            return View(new List<Category>());
        }*/
    }
}
