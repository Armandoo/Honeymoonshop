using Honeymoonshop.Controllers;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HoneymoonshopTests.Tests
{
    public class KleurenTest
    {
        [Fact]
        public void KleurenIndexInKleurenController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            var result = c.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            //check model data
            var model = (List<Kleur>)viewResult.Model;
            int aantal = model.Count();

            //checkt het aantal
            Assert.Equal(4, aantal);
            //checkt de naam van het 1e element 
            Assert.Equal("Wit", model.ElementAt(0).Naam);
            //checkt de naam van het laatste element 
            Assert.Equal("Blauw", model.ElementAt(3).Naam);
        }

        [Fact]
        public void CreateKleurInKleurenController()
        {
            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            //nieuwe kleur om toe te voegen
            var newKleur = new Kleur() { Naam = "Zwart", KleurCode = "#000000" };

            var result = c.Create(newKleur);

            //check of modelstate valid was
            Assert.True(c.ModelState.IsValid);

            //check of de action naar de goede action redirect
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", viewResult.ActionName);

            //check of de nieuwe kleur in de database is opgeslagen
            mockDbContext.Verify(m => m.Add(It.Is<Kleur>(k => k.Naam == "Zwart" && k.KleurCode == "#000000")));
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Fact]
        public void Invalid_CreateKleurInKleurenController()
        {
            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            //nieuwe kleur om toe te voegen
            var newKleur = new Kleur() { Naam = "Zwart" };

            c.ModelState.AddModelError("Error", "Geen kleurCode");

            var result = c.Create(newKleur);

            //check of modelstate valid was
            Assert.False(c.ModelState.IsValid);

            //check of de action naar de goede action redirect
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(null, viewResult.ViewName);

            //View Model checken
            var model = viewResult.Model;
            var viewModel = Assert.IsType<Kleur>(model);

            Assert.Equal("Zwart", viewModel.Naam);

            //check of de nieuwe kleur niet in de database is opgeslagen
            mockDbContext.Verify(m => m.Add(It.IsAny<Kleur>()), Times.Never());
        }


        [Fact]
        public void EditKleurViewInKleurenControllerWithoutParam()
        {
            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);


            //kleur editen zonder id
            int? kleurId = null;

            var result = c.Edit(kleurId);
            
            //check of de goede actionResult gereturned worden
            var actionResult = Assert.IsType<NotFoundResult>(result);

        }


        [Fact]
        public void EditKleurViewInKleurenControllerWithRightParams()
        {
            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);


            //kleur editen met goede id
            int? kleurId = 1;

            var result = c.Edit(kleurId);

            //check of de goede actionResult gereturned worden
            var actionResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(null, actionResult.ViewName);

            //View Model checken
            var model = actionResult.Model;
            var viewModel = Assert.IsType<Kleur>(model);


            //check of de goede kleur uit de database is gehaald
            Assert.Equal(1, viewModel.Id);
            Assert.Equal("Wit", viewModel.Naam);
            Assert.Equal("#FFFFFF", viewModel.KleurCode);

        }

        [Fact]
        public void EditKleurViewInKleurenControllerWithWrongParams()
        {
            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);
            
            //kleur editen met goede id
            int? kleurId = 5;
            
            var result = c.Edit(kleurId);

            //check of de goede actionResult gereturned worden
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void POST_EditKleurViewInKleurenControllerWithWrongParams()
        {

            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            // kleur edit params
            var id = 1;
            Kleur kleur = new Kleur()
            {
                Id = 2,
                Naam = "Rood",
                KleurCode = "#F08932"
            };

            var result = c.Edit(id, kleur);

            //check of de goede actionResult gereturned worden
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void POST_EditKleurViewInKleurenControllerWithoutAllParams()
        {

            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            // kleur edit params
            var id = 1;
            Kleur kleur = new Kleur()
            {
                Id = 1,
                Naam = "Rood",
                KleurCode = ""
            };

            c.ModelState.AddModelError("Error", "Geen kleurCode");
            var result = c.Edit(id, kleur);

            //check model state

            Assert.False(c.ModelState.IsValid);

            //check of de goede actionResult gereturned worden
            var actionResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(null, actionResult.ViewName);

            //check model
            var viewModel =  (Kleur)actionResult.Model;
            Assert.Equal(1, viewModel.Id);
            Assert.Equal("Rood", viewModel.Naam);
            Assert.Equal("", viewModel.KleurCode);

            
        }


        [Fact]
        public void POST_EditKleurViewInKleurenControllerMetParams()
        {

            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            // kleur edit params
            var id = 1;
            Kleur kleur = new Kleur()
            {
                Id = 1,
                Naam = "Rood",
                KleurCode = "#FFFFFF"
            };

            var result = c.Edit(id, kleur);

            //check model state
            Assert.True(c.ModelState.IsValid);

            //check of de kleur in de database is geupdate en opgeslagen
            mockDbContext.Verify(m => m.Update(It.Is<Kleur>(k => k.Naam == "Rood" && k.KleurCode == "#FFFFFF")));
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());

            //check of de action naar de goede action redirect
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", viewResult.ActionName);
        }

        [Fact]
        public void POST_EditKleurViewInKleurenControllerMetParamsAndKleurExist()
        {

            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            // kleur edit params
            var id = 1;
            Kleur kleur = new Kleur()
            {
                Id = 1,
                Naam = "Rood",
                KleurCode = "#FFFFFF"
            };

            var result = c.Edit(id, kleur);

            //check model state
            Assert.True(c.ModelState.IsValid);
            

            //check of de action naar de goede action redirect
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void DeleteKleur()
        {

            //init context en controller
            var mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSetKleur = initTestData();

            mockDbContext.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);

            KleurController c = new KleurController(mockDbContext.Object);

            // kleur edit params
            var id = 1;
            Kleur kleur = new Kleur()
            {
                Id = 1,
                Naam = "Rood",
                KleurCode = "#FFFFFF"
            };

            var result = c.Edit(id, kleur);

            //check model state
            Assert.True(c.ModelState.IsValid);


            //check of de action naar de goede action redirect
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
        }



        private Mock<DbSet<Kleur>> initTestData()
        {
            var mockDbSetKleur = new Mock<DbSet<Kleur>>();

            var dummyData = new List<Kleur>()
            {
                new Kleur() { Id = 1, Naam = "Wit", KleurCode = "#FFFFFF" },
                new Kleur() { Id = 2, Naam = "Rood", KleurCode = "#FF0000" },
                new Kleur() { Id = 3, Naam = "Groen", KleurCode = "#00FF00" },
                new Kleur() { Id = 4, Naam = "Blauw", KleurCode = "#0000FF" },
            }.AsQueryable();

            //alle property van IQueryable correct toekennen
            mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            return mockDbSetKleur;
        }
    }
}
