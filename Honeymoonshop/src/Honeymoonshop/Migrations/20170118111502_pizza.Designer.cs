using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Honeymoonshop.Data;

namespace Honeymoonshop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170118111502_pizza")]
    partial class pizza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Honeymoonshop.Models.Afspraak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("klantid");

                    b.HasKey("Id");

                    b.HasIndex("klantid");

                    b.ToTable("Afspraken");
                });

            modelBuilder.Entity("Honeymoonshop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAccessoire");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KenmerkType");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Kenmerken");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerkproduct", b =>
                {
                    b.Property<int>("KenmerkId");

                    b.Property<int>("ProductId");

                    b.HasKey("KenmerkId", "ProductId");

                    b.HasIndex("KenmerkId");

                    b.HasIndex("ProductId");

                    b.ToTable("KenmerkProduct");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Telefoonnummer");

                    b.Property<DateTime>("TrouwDatum");

                    b.Property<bool>("WilBrief");

                    b.HasKey("Id");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KleurCode");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Kleuren");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleurproduct", b =>
                {
                    b.Property<int>("KleurId");

                    b.Property<int>("ProductId");

                    b.HasKey("KleurId", "ProductId");

                    b.HasIndex("KleurId");

                    b.HasIndex("ProductId");

                    b.ToTable("ktKleurProduct");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Merk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MerkNaam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Merken");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artikelnummer")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.Property<int>("CategorieId");

                    b.Property<string>("Geslacht");

                    b.Property<int>("MerkId");

                    b.Property<string>("Omschrijving");

                    b.Property<int>("prijs");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("MerkId");

                    b.ToTable("Producten");
                });

            modelBuilder.Entity("Honeymoonshop.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Productid");

                    b.Property<string>("BestandsNaam");

                    b.Property<int?>("kleurproductkleurId");

                    b.Property<int?>("kleurproductproductId");

                    b.HasKey("Id");

                    b.HasIndex("Productid");

                    b.HasIndex("kleurproductkleurId", "kleurproductproductId");

                    b.ToTable("ProductAfbeeldingen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Afspraak", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Klant", "Klant")
                        .WithMany("Afspraken")
                        .HasForeignKey("klantid");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerkproduct", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Kenmerk", "Kenmerk")
                        .WithMany("Producten")
                        .HasForeignKey("KenmerkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Product", "Product")
                        .WithMany("Kenmerken")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleurproduct", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Kleur", "Kleur")
                        .WithMany("Producten")
                        .HasForeignKey("KleurId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Product", "Product")
                        .WithMany("Kleuren")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.Product", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Category", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Merk", "Merk")
                        .WithMany("Producten")
                        .HasForeignKey("MerkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.ProductImage", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Product")
                        .WithMany("Afbeeldingen")
                        .HasForeignKey("Productid");

                    b.HasOne("Honeymoonshop.Models.Kleurproduct", "Kleurproduct")
                        .WithMany("Images")
                        .HasForeignKey("kleurproductkleurId", "kleurproductproductId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Honeymoonshop.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Honeymoonshop.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
