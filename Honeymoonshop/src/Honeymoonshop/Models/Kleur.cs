using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kleur
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vul een Naam in")]
        public string Naam { get; set; }
        public string KleurCode { get; set; }

        public List<Kleurproduct> Producten { get; set; }
    }
}
