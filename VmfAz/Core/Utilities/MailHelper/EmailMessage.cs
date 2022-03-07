using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.MailHelper
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAdresses = new List<EmailAddress>();
            FromAdresses = new List<EmailAddress>();
        }

        public List<EmailAddress> FromAdresses { get; set; }
        public List<EmailAddress> ToAdresses { get; private set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
