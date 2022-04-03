using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public void SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAdresses.Select(x=> new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAdresses.Select(x=> new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            
            message.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

            //using (var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect(
            //        _configuration.GetSection("EmailConfiguration").GetSection("SmtpServer").Value,
            //        Convert.ToInt32(_configuration.GetSection("EmailConfiguration").GetSection("SmtpPort").Value),
            //        SecureSocketOptions.Auto);
            //    emailClient.Send(message);
            //    emailClient.Disconnect(true);
            //}
        }
    }
}
