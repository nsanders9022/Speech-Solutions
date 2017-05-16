using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speech.Models;

namespace Speech.Controllers
{
    public class ProfileController : Controller
    {
        private SpeechDbContext db = new SpeechDbContext();
        public IActionResult Index(string userName)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserName == userName);
            return View(userName);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
