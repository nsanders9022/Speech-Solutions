using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Speech.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Therapists()
        {
            return View();
        }

        public IActionResult Teletherapy()
        {
            return View();
        }

        public IActionResult Company()
        {
            return View();
        }
    }
}
