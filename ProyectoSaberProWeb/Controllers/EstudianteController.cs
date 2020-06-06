using Microsoft.AspNet.Identity;
using ProyectoSaberProWeb.Models;
using ProyectoSaberProWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Estudiante
        public ActionResult Index()
        {
            RespondeCompetenciaPruebaViewModel rcpvm = new RespondeCompetenciaPruebaViewModel(db);
            return View(rcpvm);
        }

        /// <summary>
        /// Este método sólo retornará la vista con la tabla de las pruebas calificadas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResolverPrueba(RespondeCompetenciaPruebaViewModel rcpvm)
        {
            return RedirectToAction("Responder","Respuestas",new { PruebaId = rcpvm.PruebaPresentando.ID, CompetenciaId = rcpvm.CompetenciaPresentando.ID });
        }

        
        public ActionResult PruebasPresentadas()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            PruebaPresentadaViewModel ppvm = new PruebaPresentadaViewModel(db, user.Email);
            return View(ppvm);
        }

        /// <summary>
        /// Retorna los resultados específicos de una prueba
        /// Por AJAX
        /// </summary>
        /// <param name="pruebaId"></param>
        /// <returns></returns>
        public ActionResult MiraResultados(int pruebaId, int competenciaId)
        {
            
            return View();
        }
        /// <summary>
        /// Desde el index llama al método para responder 
        /// una prueba específicada por un alumno
        /// </summary>
        /// <param name="pruebaId">int</param>
        /// <returns></returns>
        public ActionResult PresentaPrueba(int? PruebaId, int? CompetenciaId)
        {
            return View();
        }

        /// <summary>
        /// Retorna la vista de una pregunta para poder ser respondida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SiguienteCompetencia(int id)
        {
            return View();
        }
        /// <summary>
        /// Recoge la respuesta enviada por un estudiante y devuelve la vista de la siguiente
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonalData()
        {
            var id = User.Identity.GetUserId();
            PersonalDataViewModel pdvm = new PersonalDataViewModel(db, id);
            return View(pdvm);
        }
    }
}
