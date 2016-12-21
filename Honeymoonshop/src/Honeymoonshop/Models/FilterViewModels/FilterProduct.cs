using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.FilterViewModels
{
    public class FilterProduct
    {
        public int minPrijs { get; set; }
        public int maxPrijs { get; set; }
        public List<Product> producten { get; set; }

    }
}
