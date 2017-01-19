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

            DateTime[] datums = _context.Afspraken.GroupBy(x => x.datum.Date).Where(x => x.Count() > 2).Select(x => x.Key).ToArray();
            
            return View(datums); // geef lijst mee aan view
        }

        public IActionResult Bevestiging()
        {
            return View();
        }

        public IActionResult Afspraakmaken2(Klantafspraak klantafspraak)
        {
            ViewBag.menu = "inverted";
            return View(klantafspraak);
        }

        [HttpPost]
        public IActionResult Afspraakmaken3(Klantafspraak klantafspraak) {
            ViewBag.menu = "inverted";
            ViewBag.type = klantafspraak.type;
            if (!ModelState.IsValid) {
                return RedirectToAction("Afspraakmaken2", klantafspraak);
            }
            return View(klantafspraak);
        }

        [HttpGet]
        public IActionResult GetTijden(string date) {
            var datum = Convert.ToDateTime(date);
            var afspraken = _context.Afspraken.Where(x => x.datum.Date == datum).Select(x => x.datum.Hour).ToList();
            List<Tijd> regel = new List<Tijd>();
            regel.Add(new Tijd() { tijd = "09:30", isBeschikbaar = !afspraken.Contains(9) , isChecked = !afspraken.Contains(9) && !regel.Select(x => x.isBeschikbaar).Contains(true)});
            regel.Add(new Tijd() { tijd = "12:30", isBeschikbaar = !afspraken.Contains(12), isChecked = !afspraken.Contains(12) && !regel.Select(x => x.isBeschikbaar).Contains(true) });
            regel.Add(new Tijd() { tijd = "15:00", isBeschikbaar = !afspraken.Contains(15), isChecked = !afspraken.Contains(15) && !regel.Select(x => x.isBeschikbaar).Contains(true) });
            return new ObjectResult(regel);
        }


        [HttpPost]
        public IActionResult Bevestigafspraak(Klantafspraak klantafspraak) {
           
            _context.Klanten.Add(klantafspraak.klant);
            Afspraak afspraak = new Afspraak();
            afspraak.klant = klantafspraak.klant;
            afspraak.datum = klantafspraak.afspraakdatum;
            afspraak.type = klantafspraak.type;
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
            klantafspraak.afspraakdatum = dt;
            klantafspraak.type = typeafspraak;

            return RedirectToAction("Afspraakmaken2", klantafspraak);
        }
    }
}