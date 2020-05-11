using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using ProyectoSaberProWeb.Models;
using ProyectoSaberProWeb.Models.ViewModels;
using Microsoft.Owin.Security;

namespace ProyectoSaberProWeb.Controllers
{
    public class AdministradorController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly string adminRole = "1";
        private readonly string alumnoRole = "3";
        private readonly string docenteRole = "2";
        private IEnumerable<ApplicationUser> getUsersByRoleId(string role)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            return usuarios;
        }

        // GET: Administrador
        public ActionResult Index()
        {
            /*var usuariosAdmin = from usuarios in db.Users
                                 join roles in db.Roles 
                                 where usuarios.*/
            //Trae todos los usuarios que sean admin
            var adminUsers = this.getUsersByRoleId(adminRole);
            //return View(db.Users.ToList());
            return View(adminUsers);
        }
        public ActionResult IndexAlumnos()
        {
            var alumnoUsers = this.getUsersByRoleId(alumnoRole);

            return View(alumnoUsers);
        }
        public ActionResult IndexDocentes()
        {
            var docenteUsers = this.getUsersByRoleId(docenteRole);
            return View(docenteUsers);
        }
        // GET: Administrador/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
            //return View(applicationUser);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            ViewBag.Ciudades = new SelectList(db.ciudades, "ID", "Nombre");
            return RedirectToAction("Register", "AccountController");
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ciudades = new SelectList(db.ciudades, "ID", "Nombre", applicationUser.Ciudad_Id);
            return View(applicationUser);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,Ciudad_Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ciudad_Id = new SelectList(db.ciudades, "ID", "Nombre", applicationUser.Ciudad_Id);
            return View(applicationUser);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(string id)
        {

            //var ciudad = db.ciudades.Where(x => x.Nombre.Contains("B"));
            var ciudad = from x in db.ciudades where x.Nombre.Contains("B") select x;

            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
