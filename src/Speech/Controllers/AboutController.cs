using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Speech.Models;
using Speech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;



namespace Speech.Controllers
{
    public class AboutController : Controller
    {

        private SpeechDbContext db = new SpeechDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact c)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(c.FirstName, c.Email));
            emailMessage.To.Add(new MailboxAddress("Nicole Sanders", EnvironmentVariables.email));
            emailMessage.Subject = "Contact Form Submission";
            emailMessage.Body = new TextPart("html")
            {
                Text = string.Format("A comment was posted from the website. <br> Comment: " + c.Comment + "<br> Sender Name: " + c.FirstName + " " + c.LastName + "<br>Sender email address: " + c.Email + ".")

            };

            Console.WriteLine(c.FirstName + " " + c.Email + " " + c.Comment);

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate(EnvironmentVariables.email, EnvironmentVariables.password);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            };

            db.Contacts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Success", "About");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
