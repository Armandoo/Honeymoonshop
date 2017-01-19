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
            var producten = Context.Producten.Include(x => x.Kleuren).Include(x => x.Kleuren).ThenInclude(x => x.Images).Where(x => x.Geslacht == "bruid").ToList();

            producten.ForEach(x => x.Kleuren.Sort((k1, k2) => k2.Images.Count.CompareTo(k1.Images.Count)));

            return View(producten);
        }


        [HttpGet]
        public IActionResult Dressfinder(Filter filtercriteria)
        {
            ViewBag.menu = "inverted";
            var producten = Context.Producten.Include(x => x.Merk).Include(x => x.Kenmerken).ThenInclude(x => x.Kenmerk).Include(x => x.Kleuren).ThenInclude(x => x.Kleur).Include(x => x.Kleuren).ThenInclude(x=>x.Images).Where(x => x.Geslacht == "Bruid").ToList();
            
            producten.ForEach(x => x.Kleuren.Sort((k1, k2)=>k2.Images.Count.CompareTo(k1.Images.Count)));
            var categorieen = Context.Category.ToList();
            Category actievecat = categorieen.SingleOrDefault(x => x.Id == filtercriteria.CategorieId);

            producten = filtercriteria.filterContent(producten);

            var merken = Context.Merken.ToList();
            var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.KenmerkType == "Silhouette");
            var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.KenmerkType == "Neklijn");
            var stijlen = Context.Kenmerken.ToList().FindAll(x => x.KenmerkType == "Stijl Jurk");


            int limiet = filtercriteria.Limiet ?? 12;

            var aantalpaginas = Math.Ceiling(Convert.ToDouble(producten.Count() / limiet));
            int pagina = filtercriteria.Paginering ?? 1;

            producten = producten.Skip(pagina * limiet - limiet).Take(limiet).ToList();

            var kleur = Context.Kleuren.ToList();
            var criteria = filtercriteria;
            
            

            var soorteerMogelijkheden = new List<SelectListItem>
            {
                new SelectListItem { Text = "Prijs Laag/ Hoog", Value = "asc", Selected = (criteria.Sorteer == "asc") },
                new SelectListItem { Text = "Prijs Hoog/ Laag", Value = "desc", Selected = (criteria.Sorteer == "desc") },
            };

            var toonMogelijkheden = new List<SelectListItem>
            {
                new SelectListItem {Text = "12", Value = "12", Selected = (criteria.Limiet == 12)},
                new SelectListItem {Text = "24", Value = "24", Selected = (criteria.Limiet == 24)},
                new SelectListItem {Text = "36", Value = "36", Selected = (criteria.Limiet == 36)},
                new SelectListItem {Text = "48", Value = "48", Selected = (criteria.Limiet == 48)}
            };

            return View(new CatalogusVM()
            {
                Producten = producten.ToList(),
                Merken = merken,
                Silhouettes = kenmerkSilhouette,
                Stijlen = stijlen,
                Neklijnen = kenmerkNeklijn,
                Kleuren = kleur,
                Categorieen = categorieen,
                Criteria = criteria,
                Aantalpaginas = (int)aantalpaginas,
                SoorteerMogelijkheden = soorteerMogelijkheden,
                ToonMogelijkheden = toonMogelijkheden,
                ActieveCategorie = actievecat
            });
        }



        [HttpGet]
        public IActionResult ProductPagina(int productId, int kleurId, int merk)
        {
            ViewBag.menu = "inverted";
            //Rewritten na images met kleur zijn gekoppeld
            var hetProduct = Context.ktKleurProduct.Include(k => k.Kleur).Include(x => x.Product).ThenInclude(x => x.Merk).Include(x => x.Product.Kleuren).ThenInclude(c => c.Kleur).Include(c => c.Product.Categorie).Include(x => x.Images).Include(x => x.Product.Kenmerken).ThenInclude(x => x.Kenmerk).FirstOrDefault(kleurproduct => kleurproduct.ProductId == productId && kleurproduct.KleurId == kleurId);
            if (hetProduct == null)
            {
                return new NotFoundResult();
            }
            var gerelateerdeProducten = new List<Kleurproduct>();
            try
            {
                gerelateerdeProducten = Context.ktKleurProduct.Include(x => x.Product).ThenInclude(x => x.Merk).Include(x => x.Images).Where(kleurproduct => kleurproduct.Product.CategorieId == hetProduct.Product.CategorieId && kleurproduct.ProductId != productId && kleurproduct.KleurId == kleurId).Take(4).ToList();
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
                accessoires = Context.ktKleurProduct.Include(x => x.Product).ThenInclude(x => x.Merk).Include(x => x.Images).Where(kleurproduct => kleurproduct.KleurId == hetProduct.KleurId && kleurproduct.Product.Categorie.IsAccessoire == true).Take(4).ToList();
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
