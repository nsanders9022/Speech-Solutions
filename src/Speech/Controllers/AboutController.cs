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
//using FluentEmail.Core;
//using FluentEmail.Mailgun;



namespace Speech.Controllers
{
    public class AboutController : Controller
    {

        private SpeechDbContext db = new SpeechDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel c)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(c.FirstName, c.Email));
            emailMessage.To.Add(new MailboxAddress("Nicole Sanders", "speechsolutions2@gmail.com"));
            emailMessage.Subject = "Contact Form Submission";
            emailMessage.Body = new TextPart("html")
            {
                Text = c.Comment + " " + c.Email
            };

            Console.WriteLine(c.FirstName + " " + c.Email + " " + c.Comment);

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("speechsolutions2@gmail.com", "CannonBeach2017@");
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            };

            //db.Contacts.Add(c);
            //db.SaveChanges();
            return RedirectToAction("Success", "About");


                //var email = Email
                //    .From(c.Email)
                //    .To("speechsolutions2@gmail.com")
                //    .Subject("Comment from Form" + c.Email)
                //    .Body(c.Comment);

                //Email.DefaultSender = new MailgunSender("gmail.com",);

                //email.Send();
                ////await email.SendAsync();


        }
    }
}
