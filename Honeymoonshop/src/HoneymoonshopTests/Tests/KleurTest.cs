using Honeymoonshop.Controllers;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HoneymoonshopTests.Tests
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

            var kleur = new Kleur() { naam = "Ivoor", kleurCode = "#FFFFFF" };
            var result = await controller.Create(kleur);

            mockDbContext.Verify(x => x.Add(It.IsAny<Kleur>()), Times.Once());
            mockDbContext.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());
            mockDbContext.Verify(x => x.Add(It.Is<Kleur>(g => g.naam == "Ivoor" && g.kleurCode == "#FFFFFF")));

            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal(viewResult.ActionName, "Index");
        }



        [Fact]
        public async Task ShouldNotCreateKleur()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKleur = new Mock<DbSet<Kleur>>();
            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);
            KleurController controller = new KleurController(mockDbContext.Object);

            var kleur = new Kleur();
            var result = await controller.Create(kleur);
            
            mockDbContext.Verify(x => x.Add(It.IsNotIn<Kleur>()));

        }

        [Fact]
        public async Task ShouldEditCreateKleur()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKleur = new Mock<DbSet<Kleur>>();
            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);
            KleurController controller = new KleurController(mockDbContext.Object);
            

        }



    }
}
