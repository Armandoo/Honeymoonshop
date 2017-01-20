using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeymoonshop.Models;
using Honeymoonshop.Data;
using Honeymoonshop.Models.AfspraakViewModels;
using Honeymoonshop.Models.Utils;

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

        public IActionResult Afspraakmaken(string typeafspraak)
        {
            ViewBag.menu = "inverted";
            /*
                Vind datums waar er geen afspraken gemaakt kunnen worden / lijst met datums
             */
            ViewBag.type = typeafspraak;

            DateTime[] datums = _context.Afspraken.GroupBy(x => x.Datum.Date).Where(x => x.Count() > 2).Select(x => x.Key).ToArray();
            
            return View(datums); // geef lijst mee aan view
        }

        public IActionResult Bevestiging()
        {
            return View();
        }

        public IActionResult Afspraakmaken2(Klantafspraak klantafspraak)
        {
            ViewBag.menu = "inverted";
            ViewBag.type = klantafspraak.Type;
            return View(klantafspraak);
        }

        [HttpPost]
        public IActionResult Afspraakmaken3(Klantafspraak klantafspraak) {
            ViewBag.menu = "inverted";
            ViewBag.type = klantafspraak.Type;
            if (!ModelState.IsValid) {
                return RedirectToAction("Afspraakmaken2", klantafspraak);
            }
            return View(klantafspraak);
        }

        [HttpPost]
        public IActionResult GetTijden(string date) {
            var datum = Convert.ToDateTime(date);
            var afspraken = _context.Afspraken.Where(x => x.Datum.Date == datum).Select(x => x.Datum.Hour).ToList();
            List<Afspraaktijd> regel = new List<Afspraaktijd>();
            regel.Add(new Afspraaktijd() { Tijd = "09:30", IsBeschikbaar = !afspraken.Contains(9) , IsChecked = !afspraken.Contains(9) && !regel.Select(x => x.IsBeschikbaar).Contains(true)});
            regel.Add(new Afspraaktijd() { Tijd = "12:30", IsBeschikbaar = !afspraken.Contains(12), IsChecked = !afspraken.Contains(12) && !regel.Select(x => x.IsBeschikbaar).Contains(true) });
            regel.Add(new Afspraaktijd() { Tijd = "15:00", IsBeschikbaar = !afspraken.Contains(15), IsChecked = !afspraken.Contains(15) && !regel.Select(x => x.IsBeschikbaar).Contains(true) });
            return new ObjectResult(regel);
        }


        [HttpPost]
        public IActionResult Bevestigafspraak(Klantafspraak klantafspraak) {
            _context.Klanten.Add(klantafspraak.Klant);
            Afspraak afspraak = new Afspraak();
            afspraak.Klant = klantafspraak.Klant;
            afspraak.Datum = klantafspraak.Afspraakdatum;
            afspraak.Type  = klantafspraak.Type;
            _context.Afspraken.Add(afspraak);
            _context.SaveChanges();

            EmailSender sender = new EmailSender();
            sender.sendEmail(klantafspraak);


                return RedirectToAction("Bevestiging");
        }

        [HttpPost]
        public IActionResult Datumdoorgeven(string dueDate, string tijdstip, string typeafspraak)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var klantafspraak = new Klantafspraak();
            DateTime dt2 = Convert.ToDateTime(tijdstip);
            DateTime dt = Convert.ToDateTime(dueDate);
            TimeSpan ts = new TimeSpan(dt2.Hour, dt2.Minute, dt2.Second);
            dt = dt.Date + ts;
            klantafspraak.Afspraakdatum = dt;
            klantafspraak.Type = typeafspraak;

            return RedirectToAction("Afspraakmaken2", klantafspraak);
        }
    }
}