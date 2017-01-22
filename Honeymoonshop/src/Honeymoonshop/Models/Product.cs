using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Honeymoonshop.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Vul een artikelnummer in")]
        [MinLength(1)]
        [MaxLength(5, ErrorMessage ="Artikelnummer mag maximaal 5 tekens lang zijn")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage ="Alleen getallen zijn toegestaan")]
        public string Artikelnummer { get; set; }
        [Required(ErrorMessage ="Vul een prijs in")]
        [Range(1, 10000, ErrorMessage ="Prijs moet tussen 1 en 10.000 zijn")]
        public int Prijs { get; set; }
        public int MerkId { get; set; }
        public virtual Merk Merk { get; set; }
        public int CategorieId { get; set; }
        public String Geslacht { get; set; }
        public Category Categorie { get; set; }
        public virtual List<Kleurproduct> Kleuren { get; set; }
        public virtual List<Kenmerkproduct> Kenmerken { get; set; }
        [Required(ErrorMessage ="Vul een Omschrijving in")]
        public string Omschrijving { get; set; }
        //public List<ProductImage> Afbeeldingen { get; internal set; }
    }
}
