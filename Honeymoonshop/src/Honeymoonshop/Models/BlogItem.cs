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
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Inhoud { get; set; }
    }
}
