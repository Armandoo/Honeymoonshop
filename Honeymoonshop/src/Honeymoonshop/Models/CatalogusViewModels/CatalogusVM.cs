using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.Catalogus
{
    public class CatalogusVM
    {
        
        public IEnumerable<Merk> merken { get; set; }

        
        public IEnumerable<Kenmerk> stijlen { get; set; }

        public IEnumerable<Kenmerk> neklijnen { get; set; }
        public IEnumerable<Kenmerk> silhouettes { get; set; }
  
        public IEnumerable<Kleur> kleuren { get; set; }
        
        public IEnumerable<Product> producten { get; set; }

        public IEnumerable<Category> categorieen { get; set; }

        public Category ActieveCategorie { get; set; }
        

        public Filter criteria { get; set; }

        public int aantalpaginas { get; set; }

        public IEnumerable<SelectListItem> SoorteerMogelijkheden { get; set; }

        public IEnumerable<SelectListItem> ToonMogelijkheden { get; set; }

        //public int actieveCategorieen { set; get; }
    }
}
