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
            var thisUser = db.Profiles.FirstOrDefault(profiles => profiles.UserName == userName);
            return View(thisUser);
        }

        //public IActionResult Create( int id)
        //{
        //    var thisProfile = db.Profiles.FirstOrDefault(profile => profile.ProfileId == id);
        //    return View(thisProfile);
        //}

        //[HttpPost]
        //public IActionResult Create(Profile profile)
        //{
        //    db.Profiles.Add(profile);
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
