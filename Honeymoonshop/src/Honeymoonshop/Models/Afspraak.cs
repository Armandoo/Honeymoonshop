using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Afspraak
    {
        public int Id { get; set; }
        public Klant Klant { get; set; }
        public DateTime Datum { get; set; }
        public string Type { get; set; }
    }
}
