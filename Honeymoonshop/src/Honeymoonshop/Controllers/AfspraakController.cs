using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeymoonshop.Models;
using Honeymoonshop.Data;
using Honeymoonshop.Models.AfspraakViewModels;

namespace Honeymoonshop.Controllers
{
    public class AfspraakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Afspraakmaken()
        {
            return View();
        }

        public IActionResult Bevestiging()
        {
            return View();
        }

        public IActionResult Afspraakmaken2(Klantafspraak klantafspraak)
        {
            return View(klantafspraak);
        }

        [HttpPost]
        public IActionResult Afspraakmaken3(Klantafspraak klantafspraak) {
            return View(klantafspraak);
        }


        [HttpPost]
        public IActionResult Bevestigafspraak(Klantafspraak klantafspraak) {
            _context.Klanten.Add(klantafspraak.klant);
            Afspraak afspraak = new Afspraak();
            afspraak.klant = klantafspraak.klant;
            afspraak.datum = klantafspraak.afspraakdatum;
            _context.Afspraken.Add(afspraak);
            _context.SaveChanges();
            return RedirectToAction("Bevestiging");
        }

        [HttpPost]
        public IActionResult Datumdoorgeven(string dueDate)
        {
            var klantafspraak = new Klantafspraak();
            DateTime dt = Convert.ToDateTime(dueDate);
            klantafspraak.afspraakdatum = dt;

            return RedirectToAction("Afspraakmaken2", klantafspraak);
        }
    }
}