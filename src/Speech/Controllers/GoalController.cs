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
    public class GoalController : Controller
    {

        public SpeechDbContext _db;

        public GoalController(SpeechDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
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
            return RedirectToAction("Clients", "Admin");
        }

        public IActionResult Complete(int id)
        {
            var thisGoal = _db.Goals.FirstOrDefault(goals => goals.GoalId == id);
            thisGoal.Completed = true;
            _db.Entry(thisGoal).State = EntityState.Modified;
            _db.SaveChanges();
            return View(thisGoal);
        }


        public IActionResult Edit(int id)
        {
            var thisGoal = _db.Goals.FirstOrDefault(goals => goals.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost]
        public IActionResult Edit(Goal goal)
        {
            _db.Entry(goal).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Clients","Admin");
        }

        public IActionResult Delete(int id)
        {
            var thisGoal = _db.Goals.FirstOrDefault(goals => goals.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisGoal = _db.Goals.FirstOrDefault(goals => goals.GoalId == id);
            _db.Goals.Remove(thisGoal);
            _db.SaveChanges();
            return RedirectToAction("Clients", "Admin");
        }
    }
}
