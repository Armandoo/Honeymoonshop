using System;
using System.Collections.Generic;
using System.Linq;

namespace Honeymoonshop.Models
{
    public class Filter
    {
        public int? silhouette { get; set; }
        public int? neklijn { get; set; }
        public int[] gefilterdeKleur { get; set; }
        public int? categorieID { get; set; }
        public int[] kenmerk { get; set; }
        public int? minPrijs { get; set; }
        public int? maxPrijs { get; set; }
        public int[] merk { get; set; }
        public string sorteer { get; set; }
        public int? limiet { get; set; }
        public int? paginering { get; set; }
        

        public List<Product> filterContent(List<Product> p)
        {
            List<Product> producten = p;
            producten = filterOpCategorie(producten);
            producten = filterOpMerk(producten);
            producten = filterOpKenmerken(producten);
            producten = filterOpKleur(producten);
            producten = filterOpPrijs(producten);
            producten = soorteer(producten);            

            return producten;

        }

        public List<Product> filterOpCategorie(List<Product> producten)
        {
            if (this.categorieID != null)
            {
                producten = producten.FindAll(x => x.categorie.id == this.categorieID);
            }
            return producten;
        }
        public List<Product> filterOpPrijs(List<Product> producten)
        {
            if (this.minPrijs != null)
            {
                producten = producten.FindAll(x => x.prijs >= this.minPrijs);
            }


            if (this.maxPrijs != null)
            {
                producten = producten.FindAll(x => x.prijs <= this.maxPrijs);
            }
            return producten;
        }
        public List<Product> filterOpMerk(List<Product> producten)
        {
            if (this.merk!= null)
            {
                    producten = producten.FindAll(x => merk.Contains(x.merkId));
            }
            return producten;
        }

        public List<Product> filterOpKenmerken(List<Product> producten)
        {
            if (this.kenmerk != null)
            {
                producten = producten.FindAll(x => x.kenmerken.Any(z => kenmerk.Contains( z.kenmerk.id )));
            }
            /*
            if (this.neklijn != null)
            {
                producten = producten.FindAll(x => x.kenmerken.Any(z => z.kenmerk.id == this.neklijn));
            }

            if (this.silhouette != null)
            {
                producten = producten.FindAll(x => x.kenmerken.Any(z => z.kenmerk.id == this.silhouette));

            }*/

            return producten;
        }

        public List<Product> filterOpKleur(List<Product> producten)
        {
            if (this.gefilterdeKleur != null)
            {
                producten = producten.FindAll(x => x.kleuren.Any(z => gefilterdeKleur.Contains(z.kleur.id)));
               
            }

            return producten;
        }

        public List<Product> soorteer(List<Product> producten)
        {
            if (this.sorteer == "desc")
            {
                producten = producten.OrderByDescending(x => x.prijs).ToList();
            }
            else
            {
                producten = producten.OrderBy(x => x.prijs).ToList();
            }
            return producten;
        }

    }
}
