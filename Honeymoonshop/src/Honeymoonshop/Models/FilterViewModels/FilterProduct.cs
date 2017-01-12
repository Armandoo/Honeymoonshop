using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.FilterViewModels
{
    public class FilterProduct
    {
        public int? minPrijs { get; set; }
        public int? maxPrijs { get; set; }
        public int? merk { get; set; }
        public List<Merk> merken { get; set; }

        public int? stijl { get; set; }
        public List<Kenmerk> stijlen { get; set; }

        public List<Kenmerk> silhouette { get; set; }
        public List<Kenmerk> neklijn { get; set; }
        public List<Kleur> kleuren { get; set; }
        public List<Product> producten { get; set; }
        public List<Category> categorieen { get; set; }
        public int? categorieID { get; set; }
        //public int actieveCategorieen { set; get; }
    }
}
