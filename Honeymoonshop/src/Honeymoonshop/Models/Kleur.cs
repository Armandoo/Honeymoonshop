using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kleur
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string kleurCode { get; set; }

        public List<Kleurproduct> producten { get; set; }
    }
}
