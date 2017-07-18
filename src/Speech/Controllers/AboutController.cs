using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Speech.Models;
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

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact c)
        {      
            return View();
        }
    }
}
