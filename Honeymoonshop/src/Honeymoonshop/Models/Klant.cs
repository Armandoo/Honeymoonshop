using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Klant
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Uw invoer is te kort")]
        [Required(ErrorMessage = "Voer een Naam in")]
        public string Naam { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Dit is geen correct emailadres"), Required(ErrorMessage ="Vul een emailadres in")]
        public string Email { get; set; }
        [NotMapped]
        [Compare("Email", ErrorMessage = "Email komt niet overeen")]
        public string HerhaalEmail { get; set; }
        public bool WilBrief { get; set; }
        [Required(ErrorMessage = "Geef een trouwdatum op")]
        public DateTime TrouwDatum { get; set; }
        [Phone]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Telefoonnummer bevat alleen cijfers")]
        [MinLength(10, ErrorMessage = "Telefoonnummer is te kort")]
        public String Telefoonnummer { get; set; }
        public List<Afspraak> Afspraken { get; set; }

    }
}
