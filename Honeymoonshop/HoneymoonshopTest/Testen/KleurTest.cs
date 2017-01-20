using Honeymoonshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honeymoonshop;
using Honeymoonshop.Data;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Controllers;

namespace HoneymoonshopTest
{
    public class KleurTest
    {
        /*
          var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKleur = new Mock<DbSet<Kleur>>();
            var mockDbSetProduct = new Mock<DbSet<Product>>();
            var mockDbSetKleur_Product = new Mock<DbSet<Kleurproduct>>();
            var mockDbSetImages = new Mock<DbSet<ProductImage>>();
            var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();
            var mockDbSetKenmerkProduct = new Mock<DbSet<Kenmerkproduct>>();
            var mockDbSetMerk = new Mock<DbSet<Merk>>();
            var mockDbSetCategorie = new Mock<DbSet<Category>>();
             */

        [Fact]
        public async Task ShouldCreateKleur()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKleur = new Mock<DbSet<Kleur>>();
            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);
            KleurController controller = new KleurController(mockDbContext.Object);

            var kleur = new Kleur() { naam="Ivoor", kleurCode="#FFFFFF" };
            var result = await controller.Create(kleur);

            mockDbContext.Verify(x => x.Add(It.IsAny<Kleur>()), Times.Once());
            mockDbContext.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());
            mockDbContext.Verify(x => x.Add(It.Is<Kleur>(g => g.naam == "Ivoor" && g.kleurCode == "#FFFFFF")));
        }
    }
}
