using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.ProductViewModels
{
    public class CreateProduct
    {
        public List<Merk> Merken { get; set; }
        public List<Kenmerk> Kenmerken { get; set; }
        public List<Category> Categorieen { get; set; }
        public List<Kleur> Kleuren { get; set; }
    }
}