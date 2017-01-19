using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.FilterViewModels
{
    public class FilterProduct
    {
        
        public List<Merk> Merken { get; set; }

        
        public List<Kenmerk> Stijlen { get; set; }

        public List<Kenmerk> Neklijnen { get; set; }
        public List<Kenmerk> Silhouettes { get; set; }
  
        public List<Kleur> Kleuren { get; set; }
        
        public List<Product> Producten { get; set; }

        public List<Category> Categorieen { get; set; }
        

        public Filter Criteria { get; set; }

        public int Aantalpaginas { get; set; }
        
        //public int actieveCategorieen { set; get; }
    }
}
