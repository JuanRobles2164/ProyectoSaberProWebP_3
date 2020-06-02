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

        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly string adminRole = "1";
        private readonly string alumnoRole = "3";
        private readonly string docenteRole = "2";
        private IEnumerable<ApplicationUser> getUsersByRoleId(string role)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            return usuarios;
        }

        // GET: Administrador
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";

            //Trae todos los usuarios que sean admin
            UserViewModel adminUsers = new UserViewModel(db, adminRole, sortOrder);
            //return View(db.Users.ToList());
            return View(adminUsers);
        }
        public ActionResult IndexAlumnos(string sortOrder)
        {
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";

            UserViewModel alumnoUsers = new UserViewModel(db, alumnoRole, sortOrder);

            return View(alumnoUsers);
        }
        public ActionResult IndexDocentes(string sortOrder)
        {
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";

            UserViewModel docenteUsers = new UserViewModel(db, docenteRole, sortOrder);
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
            //return RedirectToAction("Index");
            return View(applicationUser);
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
        public ActionResult Edit(ApplicationUser applicationUser)
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
