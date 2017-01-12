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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Kleurproduct>().HasKey(kp => new { kp.kleurId, kp.productId});
            builder.Entity<Kleurproduct>().HasOne(k => k.product).WithMany(p => p.kleuren).HasForeignKey(k => k.productId);
            builder.Entity<Kleurproduct>().HasOne(k => k.kleur).WithMany(p => p.producten).HasForeignKey(k => k.kleurId);

            builder.Entity<Kenmerkproduct>().HasKey(k => new { k.kenmerkId, k.productId });
            builder.Entity<Kenmerkproduct>().HasOne(k => k.product).WithMany(p => p.kenmerken).HasForeignKey(k => k.productId);
            builder.Entity<Kenmerkproduct>().HasOne(k => k.kenmerk).WithMany(p => p.producten).HasForeignKey(k => k.kenmerkId);

            builder.Entity<Kleurproduct>().HasMany(x => x.images).WithOne(x => x.kleurproduct);
           

        }


        
    }
}
