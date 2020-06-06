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
    [Authorize(Roles = "Administrator")]
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
        public ActionResult RedirectToRegister()
        {
            return RedirectToAction("Register", "Account");
        }

        // GET: Administrador
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //Ordenamiento por columnas
            ViewBag.CurrentSort = sortOrder;
            //Se le asigna al viewbag el valor dependiendo del valor que traiga para alternal el ordenamiento entre ascendente y descendente
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";
            //condicional para saber si se tiene algun valor de textbox de busqueda

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            //Trae todos los usuarios que sean admin ordenados y paginados
            //Se le pasa la base de datos el tipo de rol de los usuarios que se quiere traer, lo que contiene el cuadro de busqueda, la pagina y el ordenamiento
            UserViewModel adminUsers = new UserViewModel(db, adminRole, sortOrder, searchString, page);


            //return View(db.Users.ToList());
            return View(adminUsers);
        }
        public ActionResult IndexAlumnos(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            UserViewModel alumnoUsers = new UserViewModel(db, alumnoRole, sortOrder, searchString, page);

            return View(alumnoUsers);
        }
        public ActionResult IndexDocentes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = sortOrder == "Nombres" ? "Nombres_desc" : "Nombres";
            ViewBag.ApellidosSortParm = sortOrder == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.UserNameSortParm = sortOrder == "Username" ? "Username_desc" : "Username";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            UserViewModel docenteUsers = new UserViewModel(db, docenteRole, sortOrder, searchString, page);

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
        public ActionResult PersonalData()
        {
            var id = User.Identity.GetUserId();
            PersonalDataViewModel pdvm = new PersonalDataViewModel(db, id);
            return View(pdvm);
        }
        [HttpPost]
        public ActionResult PersonalData(PersonalDataViewModel pdvm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdvm).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pdvm);
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
