using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speech.Models;
using Microsoft.EntityFrameworkCore;

namespace Speech.Controllers
{
    public class ProfileController : Controller
    {
        private SpeechDbContext db = new SpeechDbContext();
        public IActionResult Index(string userName)
        {
            var thisUser = db.Profiles.Include(profiles => profiles.Goals).FirstOrDefault(profiles => profiles.UserName == userName);
            return View(thisUser);
        }

        public IActionResult Edit(string userName)
        {
            var thisProfile = db.Profiles.FirstOrDefault(profiles => profiles.UserName == userName);
            return View(thisProfile);
        }

        [HttpPost]
        public IActionResult Edit(Profile profile, string userName)
        {
            db.Entry(profile).State = EntityState.Modified;
            var thisUser = db.Profiles.FirstOrDefault(profiles => profiles.UserName == userName);

            db.SaveChanges();
            return RedirectToAction("Index", new { userName = thisUser.UserName });
            
        }
    }
}
