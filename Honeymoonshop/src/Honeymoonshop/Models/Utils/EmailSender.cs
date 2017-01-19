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
            message.To.Add(new MailboxAddress(klantafspraak.Klant.Naam, klantafspraak.Klant.Email));
            message.Subject = "Bevestiging pasafspraak";
            if (klantafspraak.Type == "afspeld")
            {
                message.Body = new TextPart("plain")
                {
                    Text = "Beste " + klantafspraak.Klant.Naam + " uw afspeldafspraak is aangemaakt op de volgende datum en tijd: " + klantafspraak.Afspraakdatum
                };
            }
            else {
                message.Body = new TextPart("plain")
                {
                    Text = "Beste " + klantafspraak.Klant.Naam + " uw pasafspraak is aangemaakt op de volgende datum en tijd: " + klantafspraak.Afspraakdatum
                };
            }

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
