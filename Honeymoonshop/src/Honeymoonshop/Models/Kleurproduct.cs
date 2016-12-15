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

        public int productId { get; set; }
        public Product product { get; set; }

        public int kleurId { get; set; }
        public Kleur kleur { get; set; }
    }
}
