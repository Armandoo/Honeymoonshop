using Honeymoonshop.Models.AfspraakViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.Utils
{
    public class EmailSender
    {
        public void sendEmail(Klantafspraak klantafspraak) {
            var fromAddress = new MailAddress("honingmaantest@gmail.com", "Honingmaanwinkel");
            var toAddress = new MailAddress(klantafspraak.Klant.Email, klantafspraak.Klant.Naam);
            const string fromPassword = "bladblazer123";
            const string subject = "Pasafspraak bevestiging";
            string body = "Beste " + klantafspraak.Klant.Naam + " uw pasafspraak is bevestigd op de volgende Datum en Tijd: " + klantafspraak.Afspraakdatum;

            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress.Address, toAddress.Address)
            {
                Subject = subject,
                Body = body
            })

                smtp.Send(message);
        }
    }
}
