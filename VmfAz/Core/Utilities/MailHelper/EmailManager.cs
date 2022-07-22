using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.MailHelper
{
    public class EmailManager : IEmailService
    {
        public readonly IConfiguration _configuration;
        private readonly EmailConfiguration _emailConfiguration;

        public EmailManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _emailConfiguration = _configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
        }

        public async Task SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAdresses.Select(x=> new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAdresses.Select(x=> new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            
            message.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };
    
            using (SmtpClient emailClient = new SmtpClient())
            {
                emailClient.Connect(
                     _emailConfiguration.SmtpServer,
                    _emailConfiguration.SmtpPort,
                    SecureSocketOptions.StartTls);
                emailClient.Authenticate(
                    _emailConfiguration.SenderEmail,
                    _emailConfiguration.Password);
                await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }
        }
    }
}
