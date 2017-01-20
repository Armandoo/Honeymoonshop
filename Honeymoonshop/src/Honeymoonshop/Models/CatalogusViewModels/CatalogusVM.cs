using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.Catalogus
{
    public class CatalogusVM
    {
        
        public IEnumerable<Merk> Merken { get; set; }

        
        public IEnumerable<Kenmerk> Stijlen { get; set; }

        public IEnumerable<Kenmerk> Neklijnen { get; set; }
        public IEnumerable<Kenmerk> Silhouettes { get; set; }
  
        public IEnumerable<Kleur> Kleuren { get; set; }
        
        public IEnumerable<Product> Producten { get; set; }

        public IEnumerable<Category> Categorieen { get; set; }

        public Category ActieveCategorie { get; set; }
        

        public Filter Criteria { get; set; }

        public int Aantalpaginas { get; set; }

        public IEnumerable<SelectListItem> SoorteerMogelijkheden { get; set; }

        public IEnumerable<SelectListItem> ToonMogelijkheden { get; set; }

        //public int actieveCategorieen { set; get; }
    }
}
