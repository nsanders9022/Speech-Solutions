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
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        public SpeechDbContext _db;
        public UserManager<ApplicationUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;

        public RolesController(SpeechDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            role.NormalizedName = role.Name.ToString().ToUpper();
            _db.Roles.Add(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string roleId)
        {
            var thisRole = _db.Roles.Where(r => r.Id.Equals(roleId, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IdentityRole role)
        {
            try
            {
                var thisRole = _db.Roles.Where(r => r.Id.Equals(role.Id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                _db.Roles.Attach(thisRole);
                thisRole.Name = role.Name;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View(role);
            }
        }

        public IActionResult Delete(string RoleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteRole(string RoleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Assign()
        {
            ViewBag.RoleName = new SelectList(_db.Roles, "Name", "Name");
            ViewBag.UserName = new SelectList(_db.Users, "UserName", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string UserName, string RoleName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            await _userManager.AddToRoleAsync(user, RoleName);
            ViewBag.RoleName = new SelectList(_db.Roles, "Name", "Name");
            ViewBag.UserName = new SelectList(_db.Users, "UserName", "UserName");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ViewBag.RolesForThisUser = await _userManager.GetRolesAsync(await _userManager.FindByNameAsync(UserName));
            }
            ViewBag.RoleName = new SelectList(_db.Roles, "Name", "Name");
            ViewBag.UserName = new SelectList(_db.Users, "UserName", "UserName");
            return View("Assign");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string UserName, string RoleName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (await _userManager.IsInRoleAsync(user, RoleName))
            {
                await _userManager.RemoveFromRoleAsync(user, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            ViewBag.RoleName = new SelectList(_db.Roles, "Name", "Name");
            ViewBag.UserName = new SelectList(_db.Users, "UserName", "UserName");
            return View("Assign");
        }
    }
}