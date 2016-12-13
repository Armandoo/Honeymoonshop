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
        public int kenmerkid { get; set; }
        public string soort { get; set; }
        public string omschrijving { get; set; }
    }
}
