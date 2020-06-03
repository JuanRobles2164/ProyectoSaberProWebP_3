using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProyectoSaberProWeb.Models;

namespace ProyectoSaberProWeb.Controllers
{
    public class ContextoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contexto
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //Ordenamiento por columnas
            ViewBag.CurrentSort = sortOrder;
            //Se le asigna al viewbag el valor dependiendo del valor que traiga para alternal el ordenamiento entre ascendente y descendente
            ViewBag.DescripcionSortParm = sortOrder == "Descripcion" ? "Descripcion_desc" : "Descripcion";
            ViewBag.EstadoSortParm = sortOrder == "Estado" ? "Estado_desc" : "Estado";
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
            var contexto = db.contexto.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                contexto = contexto.Where(s => s.Descripcion.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "Descripcion":
                    contexto = contexto.OrderBy(s => s.Descripcion).ToList();
                    break;
                case "Descripcion_desc":
                    contexto = contexto.OrderByDescending(s => s.Descripcion).ToList();
                    break;
                case "Estado":
                    contexto = contexto.OrderBy(s => s.Estado).ToList();
                    break;
                case "Estado_desc":
                    contexto = contexto.OrderByDescending(s => s.Estado).ToList();
                    break;
                default:
                    contexto = contexto.OrderBy(s => s.ID).ToList();
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(contexto.ToPagedList(pageNumber, pageSize));
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
