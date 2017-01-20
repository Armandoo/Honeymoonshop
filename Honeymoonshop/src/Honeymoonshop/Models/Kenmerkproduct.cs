using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kenmerkproduct
    {
        public int KenmerkId { get; set; }
        public Kenmerk Kenmerk { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
