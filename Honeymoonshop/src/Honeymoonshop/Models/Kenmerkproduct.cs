using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kenmerkproduct
    {
        public int kenmerkId { get; set; }
        public Kenmerk kenmerk { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }

    }
}
