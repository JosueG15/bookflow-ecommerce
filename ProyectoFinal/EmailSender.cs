using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProyectoFinal.Utility
{
    public class EmailSender : IEmailSender
    {

        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration config)
        {
            SendGridSecret = config.GetValue<string>("SendGrid:SecretKey");
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(SendGridSecret);

            var from = new EmailAddress("admin@proyectofinal.net", "Proyecto Final");
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            return client.SendEmailAsync(message);
        }
    }
}
