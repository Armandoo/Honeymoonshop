using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class ProductImage
    {
        public int id { get; set; }
        public string bestandsNaam { get; set; }

        public Kleurproduct kleurproduct { get; set; }
    }
}
