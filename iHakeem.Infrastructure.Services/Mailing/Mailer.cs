using System.Net.Mail;
using System.Security.Authentication;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace iHakeem.Infrastructure.Services.Mailing
{
    public class Mailer : IMailer
    {

        public Mailer()
        {
        }
        public async Task Send(MailData data)
        {
            var client = new SendGridClient(EmailOptions.Key);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(EmailOptions.FromAddress, EmailOptions.Username),
                Subject = data.Subject,
                PlainTextContent = data.Body,
                HtmlContent = data.Body
            };
            msg.AddTo(new EmailAddress(data.To));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }
    }
}
