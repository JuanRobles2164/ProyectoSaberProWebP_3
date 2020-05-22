using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSaberProWeb.Models;

namespace ProyectoSaberProWeb.Controllers
{
    public class OpcionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opciones
        public ActionResult Index()
        {
            var opciones = db.opciones.Include(o => o.Pregunta);
            return View(opciones.ToList());
        }

        // GET: Opciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.opciones.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // GET: Opciones/Create
        public ActionResult Create()
        {
            ViewBag.PreguntaId = new SelectList(db.preguntas, "ID", "Descripcion");
            return View();
        }

        // POST: Opciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,Correcta,PreguntaId")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.opciones.Add(opcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PreguntaId = new SelectList(db.preguntas, "ID", "Descripcion", opcion.PreguntaId);
            return View(opcion);
        }

        // GET: Opciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.opciones.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.PreguntaId = new SelectList(db.preguntas, "ID", "Descripcion", opcion.PreguntaId);
            return View(opcion);
        }

        // POST: Opciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,Correcta,PreguntaId")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PreguntaId = new SelectList(db.preguntas, "ID", "Descripcion", opcion.PreguntaId);
            return View(opcion);
        }

        // GET: Opciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.opciones.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // POST: Opciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opcion opcion = db.opciones.Find(id);
            db.opciones.Remove(opcion);
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
