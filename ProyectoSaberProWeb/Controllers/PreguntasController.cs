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
    [Authorize(Roles = "Docente")]
    public class PreguntasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Preguntas
        public ActionResult Index(int? PruebaId)
        {
            PreguntaViewModel pvm;
            if (PruebaId == null)
            {
                pvm = new PreguntaViewModel(db);
            }
            else
            {
                pvm = new PreguntaViewModel(db, PruebaId);
            }
            //var preguntas = db.preguntas.Include(p => p.Competencia).Include(p => p.Contexto).Include(p => p.Prueba);
            return View(pvm);
        }
        // GET: Preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: Preguntas/Create
        /*public ActionResult Create()
        {
            ViewBag.CompentenciaId = new SelectList(db.competencias, "ID", "Nombre");
            ViewBag.ContextoId = new SelectList(db.contexto, "ID", "Descripcion");
            ViewBag.PruebaId = new SelectList(db.pruebas, "ID", "Nombre");
            return View();
        }*/

        // POST: Preguntas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PreguntaViewModel pregunta)
        {
            
            if (ModelState.IsValid)
            {
                db.preguntas.Add(pregunta.PreguntaCreacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompentenciaId = new SelectList(db.competencias, "ID", "Nombre", pregunta.CompentenciaId);
            ViewBag.ContextoId = new SelectList(db.contexto, "ID", "Descripcion", pregunta.ContextoId);
            ViewBag.PruebaId = new SelectList(db.pruebas, "ID", "Nombre", pregunta.PruebaId);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,TipoPregunta,PreguntaPeso,CompentenciaId,ContextoId,PruebaId")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompentenciaId = new SelectList(db.competencias, "ID", "Nombre", pregunta.CompentenciaId);
            ViewBag.ContextoId = new SelectList(db.contexto, "ID", "Descripcion", pregunta.ContextoId);
            ViewBag.PruebaId = new SelectList(db.pruebas, "ID", "Nombre", pregunta.PruebaId);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregunta pregunta = db.preguntas.Find(id);
            db.preguntas.Remove(pregunta);
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

        public JsonResult getOpcionesNT(int PreguntaId)
        {
            var YesOrNot = db.opciones.Where(a => a.PreguntaId == PreguntaId).Count();
            return Json(YesOrNot, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOpciones(int PreguntaId)
        {
            var opciones = db.opciones.Where(x => x.PreguntaId == PreguntaId).ToList();
            return Json(opciones, JsonRequestBehavior.AllowGet);
        }
    }
}
