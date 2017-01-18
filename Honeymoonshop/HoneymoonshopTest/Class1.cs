using Honeymoonshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop;
using Honeymoonshop.Data;
using Moq;

namespace HoneymoonshopTest
{
    public class Class1
    {
        public Class1()
        {
            var context = new Mock<ApplicationDbContext>();
        }
    }
}
