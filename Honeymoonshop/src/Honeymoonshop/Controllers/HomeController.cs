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
            var producten = Context.Producten.Include(x => x.merk).Include(x => x.kenmerken).ThenInclude(x=> x.kenmerk).Include(x=>x.kleuren).ThenInclude(x=>x.kleur).ToList();
            var categorieen = Context.Category.ToList();

            if(filtercriteria.categorieID !=null )
            {
                producten = producten.FindAll(x => x.categorie.id == filtercriteria.categorieID);
            }

            if(filtercriteria.minPrijs != null )
            {
                 producten = producten.FindAll(x => x.prijs >= filtercriteria.minPrijs);
            }

            if (filtercriteria.maxPrijs != null)
            {
                producten = producten.FindAll(x => x.prijs <= filtercriteria.maxPrijs);
            }

            if ( filtercriteria.merk != null)
            {
                    producten = producten.FindAll(x => x.merk.id == filtercriteria.merk);
            }
            
            if(filtercriteria.stijl != null)
            {
                    producten = producten.FindAll(x => x.id == filtercriteria.stijl);
            }

            if (filtercriteria.neklijn != null)
            {
                    producten = producten.FindAll(x => x.kenmerken.Any(z => z.kenmerk.id == filtercriteria.neklijn));
            }

            if (filtercriteria.silhouette != null)
            {
                    producten = producten.FindAll(x => x.kenmerken.Any(z => z.kenmerk.id == filtercriteria.silhouette));
                
            }

            if (filtercriteria.gefilterdeKleur != null)
            {
                    producten = producten.FindAll(x => x.kleuren.Any(z => z.kleur.id == filtercriteria.gefilterdeKleur));
                
            }

            if(filtercriteria.sorteer != "")
            {
                if (filtercriteria.sorteer == "desc")
                    producten = producten.OrderByDescending(x => x.prijs).ToList();
                else
                    producten = producten.OrderBy(x => x.prijs).ToList();
            }

            else
            {
                producten = producten.OrderBy(x => x.prijs).ToList();
            }

            /*if (filtercriteria.limiet != null)
            {
                producten = producten.Take(filtercriteria.limiet??0);
            }*/
           /* if (filtercriteria.paginering != null)
            {
                /*if (filtercriteria.paginering.Value != 1)
                    producten = producten.Take(2).Skip(filtercriteria.paginering.Value).ToList();*/
                int limiet = filtercriteria.limiet ?? 12;

                var aantalpaginas = Math.Ceiling(Convert.ToDouble(producten.Count() / limiet));
                int pagina = filtercriteria.paginering ?? 1;

                producten = producten.Skip(pagina*limiet-limiet).Take(limiet).ToList();

            //}


            var merken = Context.Merken.ToList();
            var kenmerkSilhouette = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Silhouette");
            var kenmerkNeklijn = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Neklijn");
            var stijlen = Context.Kenmerken.ToList().FindAll(x => x.kenmerktype == "Stijl Jurk");

            var kleur = Context.Kleuren.ToList();
            var criteria = new FilterCriteria() {
                silhouette = filtercriteria.silhouette,
                stijl = filtercriteria.stijl,
                neklijn = filtercriteria.neklijn,
                categorieID = filtercriteria.categorieID,
                sorteer = filtercriteria.sorteer,
                limiet = filtercriteria.limiet,
                paginering = filtercriteria.paginering
            };

            return View(new FilterProduct()
            {
                producten = producten.ToList(),
                merken = merken,
                silhouettes = kenmerkSilhouette,
                stijlen = stijlen,
                neklijnen = kenmerkNeklijn,
                kleuren = kleur,
                categorieen = categorieen,
                criteria = criteria,
                aantalpaginas = Convert.ToInt16(aantalpaginas)
            });
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

        public IActionResult ProductPagina(int id)
        {
            //Rewritten na images met kleur zijn gekoppeld
            var hetProduct = Context.ktKleurProduct.Include(k => k.kleur).Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.product.kleuren).Include(c => c.product.categorie).Include(x => x.images).FirstOrDefault(kleurproduct => kleurproduct.productId == id);
            List<Product> gerelateerdeProducten = new List<Product>();

            var gerelateerdProduct = Context.ktKleurProduct.Include(x => x.product).ThenInclude(x => x.merk).Include(x => x.images).Take(4).Where(kleurproduct => kleurproduct.product.categorieId == hetProduct.product.categorieId);


            /*//Oud
            var hetProduct = Context.Producten.Include(mrk => mrk.merk).Include(x => x.kleuren).ThenInclude(x => x.kleur).Include(x => x.categorie).Include(x => x.kenmerken).ThenInclude(x => x.kenmerk).Include(img => img.afbeeldingen).FirstOrDefault(product => product.id == id);
            //var hetMerk = Context.Merken.FirstOrDefault(merk => merk.id == hetProduct.merkId);
            //hetProduct.merk = hetMerk;
            List<ProductImage> productAfbeeldingen = new List<ProductImage>();
            List<Product> gerelateerdeProducten = new List<Product>();
            int i = 0;


            foreach (Product p in Context.Producten)
            {
                if (i < 4)
                {
                    p.merk = Context.Merken.FirstOrDefault(merk => merk.id == p.merkId);
                    var afb = Context.ProductAfbeeldingen.Include(prodimg => prodimg.product).FirstOrDefault(img => img.product.id == p.id);
                    List<ProductImage> afbLijst = new List<ProductImage>();
                    afbLijst.Add(afb);
                    p.afbeeldingen = afbLijst;
                    gerelateerdeProducten.Add(p);
                    i++;
                }
                else
                {
                    break;
                }
            }*/
            ViewData["gerelateerdeProducten"] = gerelateerdeProducten;
            ViewData["Product"] = hetProduct;

            return View();
        }

    }
}
