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
    public class RespuestasController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // POST: Respuestas/Create

        /// <summary>
        /// Registra la serie de respuestas de un estudiante
        /// </summary>
        /// <param name="pregunta_Estudiante"></param>
        /// <returns></returns>
        
        public ActionResult Create()
        {
            RespondeCompetenciaPruebaViewModel rcpv = new RespondeCompetenciaPruebaViewModel(db);
            return View(rcpv);
        }
        [HttpPost]
        public JsonResult Create(Pregunta_Estudiante pe)
        {
            var userEmail = User.Identity.Name;
            var userQuery = db.Users.Where(x => x.Email == userEmail).First();
            pe.User_Id = userQuery.Id;
            pe.ApplicationUser = userQuery;
            bool resultValue = true;
            try
            {
                var peQuery = db.preguntas_estudiantes.First(x => x.PreguntaId == pe.PreguntaId && x.User_Id == pe.User_Id);
                peQuery.OpcionId = pe.OpcionId;
            }
            catch (Exception)
            {
                db.preguntas_estudiantes.Add(pe);
                resultValue = false;
            }
            finally
            {
                db.SaveChanges();
            }
            return Json(resultValue);
            
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pregunta_Estudiante pregunta_Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.preguntas_estudiantes.Add(pregunta_Estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pregunta_Estudiante);
        }*/

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
