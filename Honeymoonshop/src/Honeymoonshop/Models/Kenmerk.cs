using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kenmerk
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vul een Naam in")]
        public string Naam { get; set; }
        public string KenmerkType { get; set; }
        
        public List<Kenmerkproduct> Producten { get; set; }
    }
}
