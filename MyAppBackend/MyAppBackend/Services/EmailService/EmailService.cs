using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Settings;
using MyAppBackend.Utilities;

namespace MyAppBackend.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly DataContext context;
        private readonly EmailSettings mailSettings;

        public EmailService(IOptions<EmailSettings> mailSettings, DataContext context)
        {
            this.context = context;
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(ResetEmail resetEmail)
        {
            //store code in database
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(mailSettings.Email)
            };
            email.To.Add(MailboxAddress.Parse(resetEmail.Email));
            email.Subject = "Password Reset Social Media Request";
            var builder = new BodyBuilder
            {
                HtmlBody = CustomHash.GetRandomHash()
            };
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Email, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
