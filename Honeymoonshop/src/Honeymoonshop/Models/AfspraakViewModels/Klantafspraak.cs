using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.AfspraakViewModels
{
    public class Klantafspraak
    {
        public Klant klant { get; set; }
        public DateTime afspraakdatum { get; set; }
    }
}
