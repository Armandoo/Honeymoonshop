using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kleurproduct
    {

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int KleurId { get; set; }
        public Kleur Kleur { get; set; }

        public List<ProductImage> Images { get; set; }
    }
}
