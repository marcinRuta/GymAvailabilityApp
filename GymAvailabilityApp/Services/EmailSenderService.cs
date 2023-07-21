using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace GymAvailabilityApp.Services
{




    public class EmailSenderService : IEmailSender
    {

        public EmailSenderService(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            

            MailMessage message = new MailMessage();
            message.From = new MailAddress(Options.GmailID);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(Options.GmailID, Options.GmailApiKey),
                EnableSsl = true,
            };
            smtpClient.Send(message);
            return Task.CompletedTask;
        }
    }
}
