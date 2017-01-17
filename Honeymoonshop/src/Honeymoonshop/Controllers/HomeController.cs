using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Models.FilterViewModels;

namespace Honeymoonshop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context;
        

        public HomeController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public IActionResult Dressfinder(FilterCriteria filtercriteria)
        {
            var producten = Context.Producten.Include(x => x.merk).Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).Include(x => x.kleuren).ThenInclude(x => x.kleur).ToList();
            var categorieen = Context.Category.ToList();
            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            return View(producten);

            /*var priceOut = 10000;
            int.TryParse(filterproduct.priceInputName, out priceOut);
            var producten = Context.Producten.Include(x => x.merk).ToList().FindAll(x => x.prijs <= priceOut);*/

            //var producten = Context.Producten.Where(x => x.prijs < filterproduct.maxPrijs && x.prijs > filterproduct.minPrijs ).Include(x => x.merk).ToList();
            //
            //var categorieen = Context.Category.ToList();
            /**if (filterproduct.actieveCategorieen != 0)
            {
                producten.FindAll(x => x.categorie.id == filterproduct.actieveCategorieen);
            }*/


            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            //return View(new FilterProduct()
            //{
            //    producten = producten.ToList(),
            //    merken = merken,
            //    silhouette = kenmerkSilhouette,
            //    neklijn = kenmerkNeklijn,
            //    kleuren = kleur,
            //    categorieen = categorieen
            //});
            //  }   
        }

        /*[HttpPost]
        public IActionResult Dressfinder(FilterProduct filterproduct)
        {

            var producten = Context.Producten.ToList();
            var categorieen = Context.Category.ToList();
            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            return View(producten);

            /*var priceOut = 10000;
            int.TryParse(filterproduct.priceInputName, out priceOut);
            var producten = Context.Producten.Include(x => x.merk).ToList().FindAll(x => x.prijs <= priceOut);*/

            //var producten = Context.Producten.Where(x => x.prijs < filterproduct.maxPrijs && x.prijs > filterproduct.minPrijs ).Include(x => x.merk).ToList();
            //
            //var categorieen = Context.Category.ToList();
            /**if (filterproduct.actieveCategorieen != 0)
            {
                producten.FindAll(x => x.categorie.id == filterproduct.actieveCategorieen);
            }*/
            
            
            //var merken = Context.Merken.ToList();
            //var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            //var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            //var kleur = Context.Kleuren.ToList();
            //return View(new FilterProduct()
            //{
            //    producten = producten.ToList(),
            //    merken = merken,
            //    silhouette = kenmerkSilhouette,
            //    neklijn = kenmerkNeklijn,
            //    kleuren = kleur,
            //    categorieen = categorieen
            //});
      //  }   


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
