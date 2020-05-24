using ProyectoSaberProWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    public class PruebasController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Pruebas
        public ActionResult Index()
        {

            return View();
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

        // GET: Pruebas/Create
        public ActionResult Create(Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.Name;
                //prueba.UserId 
                    
                db.pruebas.Add(prueba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Pruebas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
