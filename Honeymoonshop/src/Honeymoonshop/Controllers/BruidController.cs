using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeymoonshop.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Honeymoonshop.Controllers
{
    public class BruidController : Controller
    {
        private ApplicationDbContext Context;


        public BruidController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var producten = Context.Producten.Include(x => x.kleuren).Include(x => x.afbeeldingen).Where(x => x.geslacht == "bruid").ToList();

            return View(producten);
        }
    }
}
