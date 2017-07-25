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
    public class NoteController : Controller
    {
        public SpeechDbContext _db;

        public NoteController(SpeechDbContext db)
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
        public IActionResult Create(Note note)
        {
            note.Date = DateTime.Now.ToLocalTime();
            _db.Notes.Add(note);
            _db.SaveChanges();
            return RedirectToAction("Clients", "Admin");
        }

        public IActionResult Edit(int id)
        {
            var thisNote = _db.Notes.FirstOrDefault(notes => notes.NoteId == id);
            return View(thisNote);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            note.Date = DateTime.Now.ToLocalTime();
            _db.Entry(note).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Clients", "Admin");
        }

        public IActionResult Delete(int id)
        {
            var thisNote = _db.Notes.FirstOrDefault(notes => notes.NoteId == id);
            return View(thisNote);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisNote = _db.Notes.FirstOrDefault(notes => notes.NoteId == id);
            _db.Notes.Remove(thisNote);
            _db.SaveChanges();
            return RedirectToAction("Clients", "Admin");
        }
    }
}
