using Honeymoonshop.Controllers;
using Honeymoonshop.Data;
using Honeymoonshop.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HoneymoonshopTests.Tests
{

    public class BruidTest
    {


        //Mock<DbSet<Kleur>> mockDbSetKleur;
        //Mock<DbSet<Product>> mockDbSetProduct;
        //Mock<DbSet<Kleurproduct>> mockDbSetKleur_Product;
        //Mock<DbSet<ProductImage>> mockDbSetImages;
        //Mock<DbSet<Kenmerk>> mockDbSetKenmerk;
        //Mock<DbSet<Kenmerkproduct>> mockDbSetKenmerkProduct;
        //Mock<DbSet<Merk>> mockDbSetMerk;
        //Mock<DbSet<Category>> mockDbSetCategorie;

        //public BruidController InitProducts(Mock<ApplicationDbContext> context)
        //{

        //    mockDbSetKleur = new Mock<DbSet<Kleur>>();
        //    mockDbSetProduct = new Mock<DbSet<Product>>();
        //    mockDbSetKleur_Product = new Mock<DbSet<Kleurproduct>>();
        //    mockDbSetImages = new Mock<DbSet<ProductImage>>();
        //    mockDbSetKenmerk = new Mock<DbSet<Kenmerk>>();
        //    mockDbSetKenmerkProduct = new Mock<DbSet<Kenmerkproduct>>();
        //    mockDbSetMerk = new Mock<DbSet<Merk>>();
        //    mockDbSetCategorie = new Mock<DbSet<Category>>();


        //    var KleurDummyData = new List<Kleur>()
        //    {
        //        new Kleur() { id = 1,  naam = "rood", kleurCode = "#FF0000" },
        //        new Kleur() { id = 2,  naam = "groen", kleurCode = "#00FF00"},
        //        new Kleur() { id = 3,  naam = "blauw", kleurCode = "#0000FF" }
        //    }.AsQueryable();

        //    mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.Provider).Returns(KleurDummyData.Provider);
        //    mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.Expression).Returns(KleurDummyData.Expression);
        //    mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.ElementType).Returns(KleurDummyData.ElementType);
        //    mockDbSetKleur.As<IQueryable<Kleur>>().Setup(m => m.GetEnumerator()).Returns(KleurDummyData.GetEnumerator());



        //    context.Setup(x => x.Kleuren).Returns(mockDbSetKleur.Object);


        //    var CategorieDummyData = new List<Category>()
        //    {
        //        new Category() { id = 1, naam = "Summer" },
        //        new Category() { id = 2, naam = "Winter" },
        //    }.AsQueryable();

        //    mockDbSetCategorie.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(CategorieDummyData.Provider);
        //    mockDbSetCategorie.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(CategorieDummyData.Expression);
        //    mockDbSetCategorie.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(CategorieDummyData.ElementType);
        //    mockDbSetCategorie.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(CategorieDummyData.GetEnumerator());



        //    var MerkDummyData = new List<Merk>()
        //    {
        //        new Merk() { id = 1,  merkNaam = "LadyBird" },
        //        new Merk() { id = 2,  merkNaam = "Demetrios" }
        //    }.AsQueryable();

        //    mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.Provider).Returns(MerkDummyData.Provider);
        //    mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.Expression).Returns(MerkDummyData.Expression);
        //    mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.ElementType).Returns(MerkDummyData.ElementType);
        //    mockDbSetMerk.As<IQueryable<Merk>>().Setup(m => m.GetEnumerator()).Returns(MerkDummyData.GetEnumerator());



        //    var KenmerkDummyData = new List<Kenmerk>
        //    {
        //        new Kenmerk() { id = 1, naam = "boothals", kenmerktype="neklijn" },
        //        new Kenmerk() { id = 2, naam = "halter", kenmerktype="neklijn" },
        //        new Kenmerk() { id = 3, naam = "kant", kenmerktype="stijl" },
        //        new Kenmerk() { id = 4, naam = "verleidelijk", kenmerktype="stijl" },
        //        new Kenmerk() { id = 5, naam = "kort", kenmerktype="silhouette" },
        //        new Kenmerk() { id = 6, naam = "recht", kenmerktype="silhouette" }
        //    }.AsQueryable();

        //    mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.Provider).Returns(KenmerkDummyData.Provider);
        //    mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.Expression).Returns(KenmerkDummyData.Expression);
        //    mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.ElementType).Returns(KenmerkDummyData.ElementType);
        //    mockDbSetKenmerk.As<IQueryable<Kenmerk>>().Setup(m => m.GetEnumerator()).Returns(KenmerkDummyData.GetEnumerator());

        //    mockDbSetProduct = new Mock<DbSet<Product>>();


        //    var ProductDummyData = new List<Product>() {
        //        new Product { id=1, artikelnummer = 43, categorieId = 1, geslacht = "bruid", merkId = 1, omschrijving = "witte pak", prijs = 22 },
        //        new Product { id=2, artikelnummer = 89, categorieId = 2, geslacht = "bruidegom", merkId = 3, omschrijving = "mooie pak", prijs = 88 }
        //    }.AsQueryable();

        //    mockDbSetProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(ProductDummyData.Provider);
        //    mockDbSetProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(ProductDummyData.Expression);
        //    mockDbSetProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(ProductDummyData.ElementType);
        //    mockDbSetProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(ProductDummyData.GetEnumerator());

        //    var KleurProductDummyData = new List<Kleurproduct>()
        //    {
        //        new Kleurproduct { kleurId = 1, productId = 1 },
        //        new Kleurproduct { kleurId = 1, productId = 2 },
        //        new Kleurproduct { kleurId = 2, productId = 1 }
        //    }.AsQueryable();


        //    mockDbSetKleur_Product.As<IQueryable<Kleurproduct>>().Setup(m => m.Provider).Returns(KleurProductDummyData.Provider);
        //    mockDbSetKleur_Product.As<IQueryable<Kleurproduct>>().Setup(m => m.Expression).Returns(KleurProductDummyData.Expression);
        //    mockDbSetKleur_Product.As<IQueryable<Kleurproduct>>().Setup(m => m.ElementType).Returns(KleurProductDummyData.ElementType);
        //    mockDbSetKleur_Product.As<IQueryable<Kleurproduct>>().Setup(m => m.GetEnumerator()).Returns(KleurProductDummyData.GetEnumerator());

        //    var KenmerkproductDummyData = new List<Kenmerkproduct>()
        //    {
        //        new Kenmerkproduct { kenmerkId = 1, productId = 1 },
        //        new Kenmerkproduct { kenmerkId = 1, productId = 2 },
        //        new Kenmerkproduct { kenmerkId = 2, productId = 1 }
        //    }.AsQueryable();


        //    mockDbSetKenmerkProduct.As<IQueryable<Kenmerkproduct>>().Setup(m => m.Provider).Returns(KenmerkproductDummyData.Provider);
        //    mockDbSetKenmerkProduct.As<IQueryable<Kenmerkproduct>>().Setup(m => m.Expression).Returns(KenmerkproductDummyData.Expression);
        //    mockDbSetKenmerkProduct.As<IQueryable<Kenmerkproduct>>().Setup(m => m.ElementType).Returns(KenmerkproductDummyData.ElementType);
        //    mockDbSetKenmerkProduct.As<IQueryable<Kenmerkproduct>>().Setup(m => m.GetEnumerator()).Returns(KenmerkproductDummyData.GetEnumerator());


        //    context.Setup(x => x.Producten).Returns(mockDbSetProduct.Object);
        //    context.Setup(x => x.ktKleurProduct).Returns(mockDbSetKleur_Product.Object);
        //    context.Setup(x => x.Kenmerken).Returns(mockDbSetKenmerk.Object);
        //    context.Setup(x => x.KenmerkProduct).Returns(mockDbSetKenmerkProduct.Object);
        //    context.Setup(x => x.Merken).Returns(mockDbSetMerk.Object);
        //    context.Setup(x => x.Category).Returns(mockDbSetCategorie.Object);


        //    return new BruidController(context.Object);
        //}


        [Fact]
        public void ShouldLoadDressFinder()
        {

            var mockDbContext = new Mock<ApplicationDbContext>();

            var ProductDummyData = new List<Product>() {
                    new Product { id=1, artikelnummer = 43, categorieId = 1, geslacht = "bruid", merkId = 1, omschrijving = "witte pak", prijs = 22 },
                    new Product { id=2, artikelnummer = 89, categorieId = 2, geslacht = "bruidegom", merkId = 3, omschrijving = "mooie pak", prijs = 88 }
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(ProductDummyData.Provider);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(ProductDummyData.Expression);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(ProductDummyData.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.GetEnumerator()).Returns(ProductDummyData.GetEnumerator());

            mockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(mockSet.Object);

            mockDbContext.Setup(x => x.Producten).Returns(mockSet.Object);
            

            //    var ProductDummyData = new List<Product>() {
            //        new Product { id=1, artikelnummer = 43, categorieId = 1, geslacht = "bruid", merkId = 1, omschrijving = "witte pak", prijs = 22 },
            //        new Product { id=2, artikelnummer = 89, categorieId = 2, geslacht = "bruidegom", merkId = 3, omschrijving = "mooie pak", prijs = 88 }
            //    }.AsQueryable();
            

        }



    }
}
