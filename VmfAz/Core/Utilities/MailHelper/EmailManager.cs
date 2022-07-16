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

        public EmailManager(IConfiguration configuration)
        {
            _configuration = configuration;
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
                    _configuration.GetSection("EmailConfiguration").GetSection("SmtpServer").Value,
                    Convert.ToInt32(_configuration.GetSection("EmailConfiguration").GetSection("SmtpPort").Value),
                    SecureSocketOptions.StartTls);
                emailClient.Authenticate(
                    _configuration.GetSection("EmailConfiguration").GetSection("SenderEmail").Value, 
                    _configuration.GetSection("EmailConfiguration").GetSection("Password").Value);
                await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }
        }
    }
}
