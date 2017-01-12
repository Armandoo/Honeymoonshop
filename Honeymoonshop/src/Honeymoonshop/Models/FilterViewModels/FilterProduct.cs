using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.FilterViewModels
{
    public class FilterProduct
    {
        
        public List<Merk> merken { get; set; }

        
        public List<Kenmerk> stijlen { get; set; }

        public List<Kenmerk> neklijnen { get; set; }
        public List<Kenmerk> silhouettes { get; set; }
  
        public List<Kleur> kleuren { get; set; }
        
        public List<Product> producten { get; set; }

        public List<Category> categorieen { get; set; }
        

        public FilterCriteria criteria { get; set; }

        public int aantalpaginas { get; set; }
        
        //public int actieveCategorieen { set; get; }
    }
}
