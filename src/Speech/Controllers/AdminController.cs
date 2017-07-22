using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var clients = _db.Profiles.Include(goals => goals.Goals).Include(notes => notes.Notes).ToList();
            return View(clients);
        }

        public IActionResult Details(int id)
        {
            var thisClient = _db.Profiles.Include(profiles => profiles.Goals).Include(profiles => profiles.Notes).FirstOrDefault(profiles => profiles.ProfileId == id);
            Console.WriteLine(id);
            return View(thisClient);
        }

        public IActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(_db.Profiles, "ProfileId", "ClientFirst");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Goal goal)
        {
            goal.Completed = false;
            _db.Goals.Add(goal);
            _db.SaveChanges();
            return RedirectToAction("Clients");
        }

        public IActionResult Complete(int id)
        {
            var thisGoal = _db.Goals.FirstOrDefault(goals => goals.GoalId == id);
            thisGoal.Completed = true;
            _db.Entry(thisGoal).State = EntityState.Modified;
            _db.SaveChanges();
            return View(thisGoal);
        }

        public IActionResult CreateNote()
        {
            ViewBag.ProfileId = new SelectList(_db.Profiles, "ProfileId", "ClientFirst");
            return View();
        }

        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            note.Date = DateTime.Now.ToLocalTime();
            _db.Notes.Add(note);
            _db.SaveChanges();
            return RedirectToAction("Clients");
        }
    }
}