using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models
{
    public class Klant
    {
        public int id { get; set; }
        [RegularExpression("a-zA-Z'",
                 ErrorMessage = "Characters are not allowed."), Required]
        public string naam { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Dit is geen correct emailadres"), Required]
        public string email { get; set; }
        public bool wilBrief { get; set; }
        [Required]
        public DateTime trouwDatum { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Dit is geen correct telefoonnummer")]
        public int telefoonnummer { get; set; }
        public List<Afspraak> afspraken { get; set; }
    }
}
