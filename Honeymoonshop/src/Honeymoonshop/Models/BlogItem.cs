using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class BlogItem
    {
        [Key]
        public int id { get; set; }
        public string titel { get; set; }
        public string inhoud { get; set; }
    }
}
