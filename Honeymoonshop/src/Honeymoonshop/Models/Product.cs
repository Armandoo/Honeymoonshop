using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Honeymoonshop.Models
{
    public class Product
    {
        
        public int id { get; set; }
        public int artikelnummer { get; set; }
        public int prijs { get; set; }
        public Merk merk { get; set; }
        public virtual List<Kenmerk> kenmerken { get; set; }
        public int categorie { get; set; }
        public List<Kleur> kleuren { get; set; }
        public List<ProductImage> afbeeldingen { get; set; }
        public string omschrijving { get; set; }

    }
}
