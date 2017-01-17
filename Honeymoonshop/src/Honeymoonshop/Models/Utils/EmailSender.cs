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
            var toAddress = new MailAddress(klantafspraak.klant.email, klantafspraak.klant.naam);
            const string fromPassword = "bladblazer123";
            const string subject = "Pasafspraak bevestiging";
            string body = "Beste " + klantafspraak.klant.naam + " uw pasafspraak is bevestigd op de volgende datum en tijd: " + klantafspraak.afspraakdatum;

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
