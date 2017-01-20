using System;
using System.Collections.Generic;
using System.Linq;

namespace Honeymoonshop.Models
{
    public class Filter
    {
        public int? Silhouette { get; set; }
        public int? Neklijn { get; set; }
        public int[] Gefilterdekleur { get; set; }
        public int? CategorieId { get; set; }
        public int[] Kenmerk { get; set; }
        public int? MinPrijs { get; set; }
        public int? MaxPrijs { get; set; }
        public int[] Merk { get; set; }
        public string Sorteer { get; set; }
        public int? Limiet { get; set; }
        public int? Paginering { get; set; }
        

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
            if (this.CategorieId != null)
            {
                producten = producten.FindAll(x => x.Categorie.Id == this.CategorieId);
            }
            return producten;
        }
        public List<Product> filterOpPrijs(List<Product> producten)
        {
            if (this.MinPrijs != null)
            {
                producten = producten.FindAll(x => x.Prijs >= this.MinPrijs);
            }


            if (this.MaxPrijs != null)
            {
                producten = producten.FindAll(x => x.Prijs <= this.MaxPrijs);
            }
            return producten;
        }
        public List<Product> filterOpMerk(List<Product> producten)
        {
            if (this.Merk!= null)
            {
                    producten = producten.FindAll(x => Merk.Contains(x.MerkId));
            }
            return producten;
        }

        public List<Product> filterOpKenmerken(List<Product> producten)
        {
            if (this.Kenmerk != null)
            {
                producten = producten.FindAll(x => x.Kenmerken.Any(z => Kenmerk.Contains( z.Kenmerk.Id )));
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
            //Controleer of er is gefilterd op een kleur
            if (this.Gefilterdekleur != null)
            {
                producten = producten.FindAll(x => x.Kleuren.Any(z => Gefilterdekleur.Contains(z.Kleur.Id)));//Pakt alleen alle producten met de gefilterde kleur
                producten.ForEach(x =>x.Kleuren = x.Kleuren.OrderByDescending(z => Gefilterdekleur.Contains(z.KleurId)).ToList());//Stopt ze in de juiste volgorde zodat de juiste kleur image wordt gepakt.
            }
            else
            {
                //Er is niet op kleur gefilterd. Sorteer op basis van images
                producten.ForEach(x => x.Kleuren.Sort((k1, k2) => k2.Images.Count.CompareTo(k1.Images.Count)));
            }
            return producten;
        }

        public List<Product> soorteer(List<Product> producten)
        {
            if (this.Sorteer == "desc")
            {
                producten = producten.OrderByDescending(x => x.Prijs).ToList();
            }
            else
            {
                producten = producten.OrderBy(x => x.Prijs).ToList();
            }
            return producten;
        }

    }
}
