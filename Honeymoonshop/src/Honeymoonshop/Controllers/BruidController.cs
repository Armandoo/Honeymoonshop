using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeymoonshop.Data;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Models.Catalogus;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        [HttpGet]
        public IActionResult Dressfinder(Filter filtercriteria)
        {
            ViewBag.menu = "inverted";
            var producten = Context.Producten.Include(x => x.merk).Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).Include(x => x.kleuren).ThenInclude(x => x.kleur).Include(x => x.kleuren).ThenInclude(x=>x.images).Where(x => x.geslacht == "Bruid").ToList();
            
            producten.ForEach(x => x.kleuren.Sort((k1, k2)=>k2.images.Count.CompareTo(k1.images.Count)));
            var categorieen = Context.Category.ToList();
            Category actievecat = categorieen.SingleOrDefault(x => x.id == filtercriteria.categorieID);

            producten = filtercriteria.filterContent(producten);

            var merken = Context.Merken.ToList();
            var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            var stijlen = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Stijl Jurk");


            int limiet = filtercriteria.limiet ?? 12;

            var aantalpaginas = Math.Ceiling(Convert.ToDouble(producten.Count() / limiet));
            int pagina = filtercriteria.paginering ?? 1;

            producten = producten.Skip(pagina * limiet - limiet).Take(limiet).ToList();

            var kleur = Context.Kleuren.ToList();
            var criteria = filtercriteria;
            

            var soorteerMogelijkheden = new List<SelectListItem>
            {
                new SelectListItem { Text = "Prijs Laag/ Hoog", Value = "asc" },
                new SelectListItem { Text = "Prijs Hoog/ Laag", Value = "desc" },
            };

            var toonMogelijkheden = new List<SelectListItem>
            {
                new SelectListItem {Text = "12", Value = "12"},
                new SelectListItem {Text = "24", Value = "24"},
                new SelectListItem {Text = "36", Value = "36"},
                new SelectListItem {Text = "48", Value = "48"}
            };

            return View(new CatalogusVM()
            {
                producten = producten.ToList(),
                merken = merken,
                silhouettes = kenmerkSilhouette,
                stijlen = stijlen,
                neklijnen = kenmerkNeklijn,
                kleuren = kleur,
                categorieen = categorieen,
                criteria = criteria,
                aantalpaginas = Convert.ToInt16(aantalpaginas),
                SoorteerMogelijkheden = soorteerMogelijkheden,
                ToonMogelijkheden = toonMogelijkheden,
                ActieveCategorie = actievecat
            });
        }



        [HttpGet]
        public IActionResult ProductPagina(int productId, int kleurId, int merk)
        {
            //Rewritten na images met kleur zijn gekoppeld
            var hetProduct = Context.ktKleurProduct.Include(k => k.kleur).Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.product.kleuren).ThenInclude(c => c.kleur).Include(c => c.product.categorie).Include(x => x.images).Include(x => x.product.kenmerken).ThenInclude(x => x.kenmerk).FirstOrDefault(kleurproduct => kleurproduct.productId == productId && kleurproduct.kleurId == kleurId);
            if (hetProduct == null)
            {
                return new NotFoundResult();
            }
            var gerelateerdeProducten = new List<Kleurproduct>();
            try
            {
                gerelateerdeProducten = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Where(kleurproduct => kleurproduct.product.categorieId == hetProduct.product.categorieId && kleurproduct.productId != productId && kleurproduct.kleurId == kleurId).Take(4).ToList();
            }
            catch (Exception e)
            {

            }
            finally
            {
                ViewData["gerelateerdeProducten"] = gerelateerdeProducten;
            }

            var accessoires = new List<Kleurproduct>();
            try
            {
                accessoires = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Take(4).Where(kleurproduct => kleurproduct.kleurId == hetProduct.kleurId && kleurproduct.product.categorie.isAccessoire == true).ToList();
            }
            catch (Exception e)
            {

            }
            finally
            {
                ViewData["Accessoires"] = accessoires;
            }

            ViewData["Product"] = hetProduct;
            ViewData["Accessoires"] = accessoires;
            return View();
        }

    }


}
