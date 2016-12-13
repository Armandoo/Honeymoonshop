using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Honeymoonshop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorie() {
            return View();
        }

        public IActionResult TrouwjurkToevoegen()
        {
            ViewData["Message"] = "Trouwjurken";

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
    }
}
