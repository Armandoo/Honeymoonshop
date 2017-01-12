using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Afspraak
    {
        public int id { get; set; }
        public Klant klant { get; set; }
        public DateTime datum { get; set; }
    }
}
