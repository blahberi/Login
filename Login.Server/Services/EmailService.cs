using System.Net;
using System.Net.Mail;

namespace Login.Server.Services
{
    internal class EmailService : IEmailService
    {
        public EmailService()
        {
            
        }

        public bool TrySendEmail(Email email)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("bootlegservices4u@gmail.com", "htzm knov faer fgsw"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("your_email@gmail.com"),
                    Subject = "Test Email",
                    Body = "This is a test email sent via Gmail SMTP.",
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
