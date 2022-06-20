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
        private readonly EmailSettings _mailSettings;

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(ResetEmail resetEmail, DataContext context)
        {
            //store code in database
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Email);
            email.To.Add(MailboxAddress.Parse(resetEmail.Email));
            email.Subject = "Password Reset Social Media Request";
            var builder = new BodyBuilder();
            builder.HtmlBody = CustomHash.GetRandomHash();
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
