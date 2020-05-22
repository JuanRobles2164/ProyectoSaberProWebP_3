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
    public class ContextoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contexto
        public ActionResult Index()
        {
            return View(db.contexto.ToList());
        }

        // GET: Contexto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contexto contexto = db.contexto.Find(id);
            if (contexto == null)
            {
                return HttpNotFound();
            }
            return View(contexto);
        }

        // GET: Contexto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contexto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,Estado")] Contexto contexto)
        {
            if (ModelState.IsValid)
            {
                db.contexto.Add(contexto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contexto);
        }

        // GET: Contexto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contexto contexto = db.contexto.Find(id);
            if (contexto == null)
            {
                return HttpNotFound();
            }
            return View(contexto);
        }

        // POST: Contexto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,Estado")] Contexto contexto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contexto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contexto);
        }

        // GET: Contexto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contexto contexto = db.contexto.Find(id);
            if (contexto == null)
            {
                return HttpNotFound();
            }
            return View(contexto);
        }

        // POST: Contexto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contexto contexto = db.contexto.Find(id);
            db.contexto.Remove(contexto);
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
