using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speech.ViewModels;
using Speech.Models;
using Microsoft.AspNetCore.Identity;

namespace Speech.Controllers
{
    public class HomeController : Controller
    {
        private SpeechDbContext db = new SpeechDbContext();

        public IActionResult Index()
        {
            return View(db.Reviews.ToList());
        }

        public IActionResult About()
        {
            return View();
        }
    }
}