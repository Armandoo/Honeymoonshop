using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Attribute
    {
        [Key]
        public int Kenmerkid { get; set; }
        public string Soort { get; set; }
        public string Omschrijving { get; set; }
    }
}
