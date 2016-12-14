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
        public string merk { get; set; }
        public int categorie { get; set; }

        public Product()
        {
            this.categorie = 10;
        }
    }
}
