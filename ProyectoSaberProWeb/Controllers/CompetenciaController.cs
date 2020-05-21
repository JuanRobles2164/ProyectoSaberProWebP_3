using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSaberProWeb.Models;
using ProyectoSaberProWeb.Models.ViewModels;

namespace ProyectoSaberProWeb.Controllers
{
    public class CompetenciaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Competencia
        public ActionResult Index()
        {
            CompetenciaViewModel competencias = new CompetenciaViewModel(db);
            return View(competencias);
        }

        // GET: Competencia/Details/5
        public JsonResult Details(int? id)
        {
            if (id == null)
            {
                return Json("No encontrado");
            }
            Competencia competencia = db.competencias.Find(id);
            return Json(competencia, JsonRequestBehavior.AllowGet);
        }
        // POST: Competencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompetenciaViewModel competencia)
        {
            if (ModelState.IsValid)
            {
                db.competencias.Add(competencia.CompetenciaCreacion);
                db.SaveChanges();
                competencia.ListaCompetencias = db.competencias.ToList();
                competencia.Message = "Exito";
                return View("Index", competencia);
            }
            competencia.ListaCompetencias = db.competencias.ToList();
            competencia.Message = "Error";
            return View("Index", competencia);
        }

        // GET: Competencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // POST: Competencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencia);
        }

        // GET: Competencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // POST: Competencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competencia competencia = db.competencias.Find(id);
            db.competencias.Remove(competencia);
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
