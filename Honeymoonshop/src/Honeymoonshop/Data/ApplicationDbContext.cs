using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Honeymoonshop.Models;

namespace Honeymoonshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Product> Producten { get; set; }
        public virtual DbSet<Kleur> Kleuren { get; set; }
        public virtual DbSet<Kenmerk> Kenmerken { get; set; }
        public virtual DbSet<Kenmerkproduct> KenmerkProduct { get; set; }
        public virtual DbSet<Merk> Merken { get; set; }
        public virtual DbSet<ProductImage> ProductAfbeeldingen { get; set; }

        public virtual DbSet<Kleurproduct> ktKleurProduct { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Klant> Klanten { get; set; }
        public virtual DbSet<Afspraak> Afspraken { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Kleurproduct>().HasKey(kp => new { kp.KleurId, kp.ProductId});
            builder.Entity<Kleurproduct>().HasOne(k => k.Product).WithMany(p => p.Kleuren).HasForeignKey(k => k.ProductId);
            builder.Entity<Kleurproduct>().HasOne(k => k.Kleur).WithMany(p => p.Producten).HasForeignKey(k => k.KleurId);

            builder.Entity<Kenmerkproduct>().HasKey(k => new { k.KenmerkId, k.ProductId });
            builder.Entity<Kenmerkproduct>().HasOne(k => k.Product).WithMany(p => p.Kenmerken).HasForeignKey(k => k.ProductId);
            builder.Entity<Kenmerkproduct>().HasOne(k => k.Kenmerk).WithMany(p => p.Producten).HasForeignKey(k => k.KenmerkId);

            builder.Entity<Kleurproduct>().HasMany(x => x.Images).WithOne(x => x.Kleurproduct);
           

        }


        
    }
}
