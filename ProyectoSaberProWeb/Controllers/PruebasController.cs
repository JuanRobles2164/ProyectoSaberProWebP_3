using ProyectoSaberProWeb.Models;
using ProyectoSaberProWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    [Authorize(Roles = "Docente")]
    public class PruebasController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Pruebas
        public ActionResult Index()
        {
            PruebaViewModel pvm = new PruebaViewModel(db);
            return View(pvm);
        }

        // GET: Pruebas/Details/5
        public JsonResult Details(int? id)
        {
            if (id == null)
            {
                return Json(new { status = "Error"}, JsonRequestBehavior.AllowGet);
            }
            var prueba = db.pruebas.Find(id);
            return Json(prueba, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(PruebaViewModel prueba)
        {
            var userEmail = User.Identity.Name;
            var userQuery = db.Users.Where(x => x.Email == userEmail).First();
            prueba.PruebaCreacion.UserId = userQuery.Id;
            prueba.PruebaCreacion.ApplicationUser = userQuery;
            if (ModelState.IsValid)
            {
                db.pruebas.Add(prueba.PruebaCreacion);
                db.SaveChanges();
                return RedirectToAction("Index", prueba);
            }
            return View("Index",prueba);
        }

        // GET: Pruebas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pruebas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pruebas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
