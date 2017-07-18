using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
//using System.Net.Mail;
using Speech.Models;


namespace Speech.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact c)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
