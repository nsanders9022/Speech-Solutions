using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Speech.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Milestones()
        {
            return View();
        }

        public IActionResult Resources()
        {
            return View();
        }
    }
}
