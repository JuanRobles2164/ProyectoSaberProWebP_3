using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Este método sólo retornará la vista con la tabla de las pruebas calificadas
        /// </summary>
        /// <returns></returns>
        public ActionResult MiraResultados()
        {
            return View();
        }

        /// <summary>
        /// Retorna los resultados específicos de una prueba
        /// Por AJAX
        /// </summary>
        /// <param name="pruebaId"></param>
        /// <returns></returns>
        public JsonResult MiraResultados(int? pruebaId)
        {
            return Json("true");
        }
        /// <summary>
        /// Desde el index llama al método para responder 
        /// una prueba específicada por un alumno
        /// </summary>
        /// <param name="pruebaId">int</param>
        /// <returns></returns>
        public ActionResult PresentaPrueba(int? pruebaId)
        {
            return View();
        }

        /// <summary>
        /// Retorna la vista de una pregunta para poder ser respondida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RespondePregunta(int id)
        {
            return View();
        }
        /// <summary>
        /// Recoge la respuesta enviada por un estudiante y devuelve la vista de la siguiente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RespondePregunta()
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


        // POST: Estudiante/Edit/5
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

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiante/Delete/5
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
