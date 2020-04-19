using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;


namespace SecurityDemo
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //SmtpClient client = new SmtpClient();
            //return client.SendMailAsync("email from web.config here",
            //                            message.Destination,
            //                            message.Subject,
            //                            message.Body);

            var smtp = new SmtpClient();
            var mail = new MailMessage();
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string username = smtpSection.Network.UserName;

            mail.IsBodyHtml = true;
            mail.From = new MailAddress(username);
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            smtp.Timeout = 1000;

            var t = Task.Run(() => smtp.SendAsync(mail, null));

            return t;
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

  
}
