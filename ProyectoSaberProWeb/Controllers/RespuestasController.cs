﻿using System;
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
    [Authorize(Roles = "Alumno,Administrador,Docente")]
    public class RespuestasController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly int PRUEBA_FINALIZADA = -1;
        // POST: Respuestas/Create

        /// <summary>
        /// Registra la serie de respuestas de un estudiante
        /// </summary>
        /// <param name="pregunta_Estudiante"></param>
        /// <returns></returns>
        
        public ActionResult Responder(int? CompetenciaId, int? PruebaId)
        {
            var userEmail = User.Identity.Name;
            var userQuery = db.Users.Where(x => x.Email == userEmail).First();
            int competencia_id;
            int prueba_id;
            if (CompetenciaId == PRUEBA_FINALIZADA)
            {
                var PruebaPresentada = db.pruebas.Find(PruebaId);
                Prueba_Estudiante pe = new Prueba_Estudiante() { ApplicationUser = userQuery, Prueba = PruebaPresentada };
                db.pruebas_estudiantes.Add(pe);
                db.SaveChanges();
                return RedirectToAction("Index", "Estudiante");
            }
            if (CompetenciaId == null)
            {
                competencia_id = ViewBag.CompetenciaId;
            }
            else
            {
                competencia_id = Int32.Parse(""+ CompetenciaId);
            }
            if (PruebaId == null)
            {
                prueba_id = ViewBag.PruebaId;
            }
            else
            {
                prueba_id = Int32.Parse(""+PruebaId);
            }
            if (db.pruebas_estudiantes.Where(x => x.UserId== userQuery.Id && x.ID == prueba_id).ToList().Count >= 1)
            {
                ViewBag.Advertencia = "Usted ya presentó esta prueba";
                return RedirectToAction("Index", "Estudiante");
            }
            RespondeCompetenciaPruebaViewModel rcpv = new RespondeCompetenciaPruebaViewModel(db, competencia_id, prueba_id);

            rcpv.CompletarCompetencia(db, userQuery.Id, competencia_id, prueba_id);
            rcpv.DeterminarCompetenciasFaltantes(db, userQuery.Id, prueba_id);
            ViewBag.CompetenciaId = competencia_id;
            ViewBag.PruebaId = prueba_id;
            return View("Create", rcpv);
        }
        [HttpPost]
        public JsonResult GuardaRespuesta(Pregunta_Estudiante pe)
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
