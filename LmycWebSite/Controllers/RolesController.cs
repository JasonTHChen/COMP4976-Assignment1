using LmycDataLib.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LmycWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public RolesController()
        {
        }

        public RolesController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Roles
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
            return View(Roles);
        }
        
        // GET: Roles/Create
		public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Roles/Edit
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(id)).ToList();
            ViewBag.Role = role.Name;

            return View(users);
        }

        // POST: Roles/Delete
        [HttpPost]
        public ActionResult Delete(string id)
        {
            IdentityRole role = db.Roles.FirstOrDefault(r => r.Id == id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Roles/Remove
        [HttpPost]
        public ActionResult Remove(string userId, string roleName)
        {
            if (userId != null)
            {
                Console.WriteLine(userId);
                Console.WriteLine(roleName);
                UserManager.RemoveFromRoles(userId, roleName);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}