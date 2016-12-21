using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string naam { get; set; }
        public bool isAccessoire { get; set; }
    }
}