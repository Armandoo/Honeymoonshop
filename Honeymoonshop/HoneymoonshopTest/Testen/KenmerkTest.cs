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

namespace HoneymoonshopTest.Testen
{
    public class KenmerkTest
    {
       /* [Fact]
        public async Task ShouldCreateKenmerk()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
           
            var mockDbSetKleur = new Mock<DbSet<Kenmerk>>();
            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKleur.Object);
            KenmerkController controller = new KenmerkController(mockDbContext.Object);

            var kenmerk = new Kenmerk() { kenmerktype= "Lang", naam="Ladybird" };
            var result = await controller.Create(kenmerk);

            mockDbContext.Verify(x => x.Add(It.IsAny<Kenmerk>()), Times.Once());
            mockDbContext.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());
            mockDbContext.Verify(x => x.Add(It.Is<Kenmerk>(g => g.kenmerktype == "Lang" && g.naam == "Ladybird")));

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public async Task ShouldNotCreateKenmerk()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKleur = new Mock<DbSet<Kenmerk>>();

            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKleur.Object);
            KenmerkController controller = new KenmerkController(mockDbContext.Object);
            
            var kenmerk = new Kenmerk();
            var result = await controller.Create(kenmerk);
         
           mockDbContext.Verify(x => x.Add(It.IsNotIn<Kenmerk>()));

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public async Task ShouldEditKenmerk()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();

            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKenmerk.Object);
            KenmerkController controller = new KenmerkController(mockDbContext.Object);

            var kenmerk = new Kenmerk() { id = 1, naam = "Kort" };
            var result = await controller.Edit(kenmerk.id, kenmerk);
            
            mockDbContext.Verify(x => x.Update(It.IsAny<Kenmerk>()), Times.Once());
            mockDbContext.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

      
        [Fact]
        public async Task ShouldNotEditKenmerk()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();

            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKenmerk.Object);
            KenmerkController controller = new KenmerkController(mockDbContext.Object);

            var kenmerk = new Kenmerk() { id = 1, naam = "Kort" };
            var result = await controller.Edit(1, kenmerk);

            mockDbContext.Verify(x => x.Update(It.IsNotIn<Kenmerk>()));

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }


        /*[Fact]
        public void ShouldDeleteKenmerk()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();

            

            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKenmerk.Object);
             KenmerkController controller = new KenmerkController(mockDbContext.Object);
            var kenmerk = new Kenmerk() { id = 1, naam = "Kort" };

             var result = controller.DeleteConfirmed(1);


            //mockDbContext.Verify(x => x.Remove(It.Is<Kenmerk>(z=>z.id == kenmerk.id)),Times.Once());


           // mockDbContext.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());


            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }*/

        /* [Fact]
         public void ShouldGetKenmerkDetails()
         {
             var mockDbContext = new Mock<ApplicationDbContext>();
             var mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();

             var KenmerkDummyData = new List<Kenmerk>
             {
                 new Kenmerk() { id = 1, naam = "boothals", kenmerktype="neklijn" },

             }.AsQueryable();

             mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.Provider).Returns(KenmerkDummyData.Provider);
             mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.Expression).Returns(KenmerkDummyData.Expression);
             mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.ElementType).Returns(KenmerkDummyData.ElementType);
             mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.GetEnumerator()).Returns(KenmerkDummyData.GetEnumerator());

             mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetKenmerk.Object);
             KenmerkController controller = new KenmerkController(mockDbContext.Object);

             //var kenmerk = new Kenmerk() { naam = "Kort" };
             var result = controller.Details(KenmerkDummyData.First().id);



             //var resultaat = controller.ModelState.IsValid;

            // mockDbContext.Verify(x => x.Kenmerken(It.IsAny<Kenmerk>()), Times.Once());


             var viewResult = Assert.IsType<IActionResult>(result);
             //Assert.Equal("Index", viewResult.ViewName);
             Assert.Equal(1, 1);
             //Assert.Equal("Details", viewResult);
         }


        [Fact]
        public async void ShouldCreateStudent()
        {
            var contextMock = new Mock<ApplicationDbContext>();
            var setMock = new Mock<DbSet<Kenmerk>>();

            var student =  new Kenmerk() { naam = "Lang", kenmerktype = "Stijljurk " } ;
            SetupKenmerkSet(new List<Kenmerk>());


            contextMock.Setup(x => x.Kenmerken).Returns(setMock.Object);

            var controller = new KenmerkController(contextMock.Object);
            var result = await controller.Create(student);

            setMock.Verify(x => x.Add(It.IsAny<Kenmerk>()), Times.Once());
            contextMock.Verify(x => x.SaveChangesAsync(new System.Threading.CancellationToken()), Times.Once());

            setMock.Verify(m => m.Add(It.Is<Kenmerk>(g => g.naam == "Lang" && g.id == 1)));


        }

        private Mock<DbSet<Kenmerk>> SetupKenmerkSet(List<Kenmerk> dummy)
        {
            var dummyData = dummy.AsQueryable();
            var mockDbSetStudent = new Mock<DbSet<Kenmerk>>();

            //alle property van IQueryable correct toekennen
            mockDbSetStudent.As<IQueryable<Kenmerk>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetStudent.As<IQueryable<Kenmerk>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetStudent.As<IQueryable<Kenmerk>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetStudent.As<IQueryable<Kenmerk>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            return mockDbSetStudent;
        }
        [Fact]
        public void ShouldGetKenmerkDetails()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var dummyData = new List<Kenmerk>() { new Kenmerk() { naam = "Lang" } };

            var mockDbSetStudent = SetupKenmerkSet(dummyData);
            mockDbContext.Setup(x => x.Kenmerken).Returns(mockDbSetStudent.Object);

            KenmerkController c = new KenmerkController(mockDbContext.Object);
            var result = c.Details(1);

            //result moet een view zijn
            var viewResult = Assert.IsType<ViewResult>(result);

            //check model data
            var model = (IQueryable<Kenmerk>)viewResult.Model;
            int aantal = model.Count();

            //checkt het aantal
            Assert.Equal(1, aantal);
            //checkt de naam van het 1e element 
            Assert.Equal("Lang", model.ElementAt(0).naam);
        }*/
    }
}
