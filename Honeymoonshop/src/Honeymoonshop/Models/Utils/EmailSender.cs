using Honeymoonshop.Models.AfspraakViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Honeymoonshop.Models.Utils
{
    public class EmailSender
    {
        public void sendEmail(Klantafspraak klantafspraak) {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Honeymoonshop", "honingmaantest@gmail.com"));
            message.To.Add(new MailboxAddress(klantafspraak.klant.naam, klantafspraak.klant.email));
            message.Subject = "Bevestiging pasafspraak";
            message.Body = new TextPart("plain")
            {
                Text = "Beste " + klantafspraak.klant.naam + " uw pasafspraak is aangemaakt op de volgende datum en tijd: " + klantafspraak.afspraakdatum
            };

            using (var client = new SmtpClient()) {
                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("honingmaantest@gmail.com", "bladblazer123");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
