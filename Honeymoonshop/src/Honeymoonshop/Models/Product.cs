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
        [Key]
        public int artikelnummer { get; set; }
        public int minimaleprijs { get; set; }
        public int maximaleprijs { get; set; }
        public string merk { get; set; }
        public int categorie { get; set; }
    }
}
