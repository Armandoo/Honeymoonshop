﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Kenmerk
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string stijl { get; set; }
        public string neklijn { get; set; }
        public string silhouette { get; set; }

        public List<Kenmerkproduct> producten { get; set; }
    }
}