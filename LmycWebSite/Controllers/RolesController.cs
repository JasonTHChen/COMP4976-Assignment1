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

        // GET: Roles/Index
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }
        
        // GET: Roles/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            ViewBag.RoleName = role.Name;
            ViewBag.RoleId = role.Id;

            return View(users);
        }

        // POST: Roles/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            if (id != null)
            {
                IdentityRole role = db.Roles.FirstOrDefault(r => r.Id == id);
                if (!role.Name.Equals("Admin") && role != null)
                {
                    db.Roles.Remove(role);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        // POST: Roles/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(string userId, string roleName)
        {
            if (userId != null && roleName != null)
            {
                ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (!user.UserName.Equals("a") && user != null)
                {
                    await UserManager.RemoveFromRoleAsync(userId, roleName);
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Roles/Add
        public ActionResult Add(string id)
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
            var usersInRole = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(id)).ToList();

            ViewBag.RoleName = role.Name;
            ViewBag.RoleId = role.Id;

            var users = db.Users.ToList();

            foreach (var u in usersInRole)
            {
                if (users.Contains(u))
                {
                    users.Remove(u);
                }
            }

            return View(users);
        }

        // POST: Roles/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(string userId, string roleName)
        {
            await UserManager.AddToRoleAsync(userId, roleName);
            
            return RedirectToAction("Index");
        }
    }
}