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
        public int id { get; set; }
        [MinLength(2, ErrorMessage = "Uw invoer is te kort")]
        [Required(ErrorMessage = "Voer een naam in")]
        public string naam { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Dit is geen correct emailadres"), Required]
        public string email { get; set; }
        [NotMapped]
        [Compare("email", ErrorMessage = "Email komt niet overeen")]
        public string herhaalEmail { get; set; }
        public bool wilBrief { get; set; }
        [Required(ErrorMessage = "Geef een trouwdatum op")]
        public DateTime trouwDatum { get; set; }
        [Phone]
        public String telefoonnummer { get; set; }
        public List<Afspraak> afspraken { get; set; }

    }
}
