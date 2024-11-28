using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Login.Server.Services
{
    internal class EmailService : IEmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string senderAddress;
        private readonly string senderPassword;

        public EmailService()
        {
            this.smtpHost = ConfigurationManager.AppSettings["SMTPServer"];
            this.smtpPort = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
            this.senderAddress = ConfigurationManager.AppSettings["SenderAddress"];
            this.senderPassword = ConfigurationManager.AppSettings["SenderPassword"];
        }

        public bool TrySendEmail(Email email)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(this.smtpHost, this.smtpPort)
                {
                    Credentials = new NetworkCredential(this.senderAddress, this.senderPassword),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(this.senderAddress),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = false,
                };

                foreach (string recipient in email.Recipients)
                {
                    mailMessage.To.Add(recipient);
                }

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
