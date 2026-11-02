using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp.Helpers
{
    public  class EmailHelper
    {
        public async Task SendEmailAsync(
    string recipient,
    string subject,
    string body)
        {
            string senderEmail = "@gmail.com";
            string appPassword = "your16characterapppassword";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(
                        senderEmail, appPassword);

                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 15000;

                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
