using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string BestandsNaam { get; set; }

        public Kleurproduct Kleurproduct { get; set; }
    }
}