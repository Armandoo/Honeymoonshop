using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Merk
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vul een Naam in")]
        public string MerkNaam { get; set; }
        public virtual List<Product> Producten { get; set; }
    }
}
