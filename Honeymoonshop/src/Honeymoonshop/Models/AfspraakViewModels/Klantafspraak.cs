using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.AfspraakViewModels
{
    public class Klantafspraak
    {
        public Klant Klant { get; set; }
        public DateTime Afspraakdatum { get; set; }
        public string Type { get; set; }
    }
}
