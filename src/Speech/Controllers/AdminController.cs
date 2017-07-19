using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Speech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
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
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Users = _db.Users.ToList();
            ViewBag.Profiles = _db.Profiles.ToList();
            return View();
        }
    }
}