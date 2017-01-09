using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Klant
    {
        public int id { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string email { get; set; }
        public bool wilBrief { get; set; }
        public DateTime trouwDatum { get; set; }
        public int telefoonnummer { get; set; }
        public List<Afspraak> afspraken { get; set; }
    }
}
