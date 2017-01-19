using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Honeymoonshop.Data;

namespace Honeymoonshop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Honeymoonshop.Models.Afspraak", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datum");

                    b.Property<int?>("klantid");

                    b.Property<string>("type");

                    b.HasKey("id");

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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isAccessoire");

                    b.Property<string>("naam");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("kenmerktype");

                    b.Property<string>("naam");

                    b.HasKey("id");

                    b.ToTable("Kenmerken");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerkproduct", b =>
                {
                    b.Property<int>("kenmerkId");

                    b.Property<int>("productId");

                    b.HasKey("kenmerkId", "productId");

                    b.HasIndex("kenmerkId");

                    b.HasIndex("productId");

                    b.ToTable("KenmerkProduct");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Klant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("naam")
                        .IsRequired();

                    b.Property<string>("telefoonnummer");

                    b.Property<DateTime>("trouwDatum");

                    b.Property<bool>("wilBrief");

                    b.HasKey("id");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("kleurCode");

                    b.Property<string>("naam");

                    b.HasKey("id");

                    b.ToTable("Kleuren");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleurproduct", b =>
                {
                    b.Property<int>("kleurId");

                    b.Property<int>("productId");

                    b.HasKey("kleurId", "productId");

                    b.HasIndex("kleurId");

                    b.HasIndex("productId");

                    b.ToTable("ktKleurProduct");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Merk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("merkNaam");

                    b.HasKey("id");

                    b.ToTable("Merken");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("artikelnummer");

                    b.Property<int>("categorieId");

                    b.Property<string>("geslacht");

                    b.Property<int>("merkId");

                    b.Property<string>("omschrijving");

                    b.Property<int>("prijs");

                    b.HasKey("id");

                    b.HasIndex("categorieId");

                    b.HasIndex("merkId");

                    b.ToTable("Producten");
                });

            modelBuilder.Entity("Honeymoonshop.Models.ProductImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Productid");

                    b.Property<string>("bestandsNaam");

                    b.Property<int?>("kleurproductkleurId");

                    b.Property<int?>("kleurproductproductId");

                    b.HasKey("id");

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
                    b.HasOne("Honeymoonshop.Models.Klant", "klant")
                        .WithMany("afspraken")
                        .HasForeignKey("klantid");
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kenmerkproduct", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Kenmerk", "kenmerk")
                        .WithMany("producten")
                        .HasForeignKey("kenmerkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Product", "product")
                        .WithMany("kenmerken")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.Kleurproduct", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Kleur", "kleur")
                        .WithMany("producten")
                        .HasForeignKey("kleurId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Product", "product")
                        .WithMany("kleuren")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.Product", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Category", "categorie")
                        .WithMany()
                        .HasForeignKey("categorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Honeymoonshop.Models.Merk", "merk")
                        .WithMany("producten")
                        .HasForeignKey("merkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Honeymoonshop.Models.ProductImage", b =>
                {
                    b.HasOne("Honeymoonshop.Models.Product")
                        .WithMany("afbeeldingen")
                        .HasForeignKey("Productid");

                    b.HasOne("Honeymoonshop.Models.Kleurproduct", "kleurproduct")
                        .WithMany("images")
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
