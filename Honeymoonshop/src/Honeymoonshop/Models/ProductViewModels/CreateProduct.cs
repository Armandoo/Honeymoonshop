using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.ProductViewModels
{
    public class CreateProduct
    {
        public SelectList Merken { get; set; }
        public List<Kenmerk> Kenmerken { get; set; }
        public SelectList Categorieen { get; set; }
        public List<Kleur> Kleuren { get; set; }
        public Product Product { get; set; }
    }
}