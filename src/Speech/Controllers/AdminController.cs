using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speech.Models;
using Microsoft.EntityFrameworkCore;

namespace Speech.Controllers
{
    public class AdminController : Controller
    {
        public SpeechDbContext _db;

        public AdminController(SpeechDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult Clients()
        {
            var clients = _db.Profiles.ToList();
            return View(clients);
        }

        public IActionResult Details(int id)
        {
            var thisClient = _db.Profiles.Include(profiles => profiles.Goals).FirstOrDefault(profiles => profiles.ProfileId == id);
            return View(thisClient);
        }
    }
}