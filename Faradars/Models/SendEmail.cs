using Faradars.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Faradars.Models
{
    public class SendEmail : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var qservice = db.tanzimatEmails.FirstOrDefault();

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, "خریدار محترم"));
                message.From = new MailAddress("mvc9899@gmail.com", "فرادرس");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("mvc9899@gmail.com", "Mvc9899/*-");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }


            return Task.FromResult(0);
        }

    }
}
