using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoSaberProWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class CalificarPruebaViewModel
    {
        public int PuntajePrueba { get; set; }
        public Competencia CompetenciaActual { get; set; }
        public Prueba PruebaPresentada { get; set; } = new Prueba();
        public int PuntajeCompetencia { get; set; }
        public int PuntajePosibleCompetencia { get; set; }
        public int PuntajePosible { get; set; }
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        public List<Opcion> OpcionesCorrectas { get; set; } = new List<Opcion>();
        public List<Pregunta_Estudiante> OpcionesRespondidas { get; set; } = new List<Pregunta_Estudiante>();
        public Dictionary<int, Opcion> OpcionesMarcadasLabel { get; set; } = new Dictionary<int, Opcion>();

        /// <summary>
        /// Diccionario para saber si el estudiante respondio correctamente la pregunta Dictionary <int (pregunta), int (opcion)>
        /// </summary>
        public void CalcularPuntajePrueba(ApplicationDbContext db, string idUser)
        {
            var user = db.Users.Find(idUser);
            string body = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/Estudiante/BodyCuerpoMsg.html"));
            body = body.Replace("#Nombre de la prueba#", PruebaPresentada.Nombre);
            body = body.Replace("#PuntuacionSacada#",Convert.ToString(PuntajePrueba));
            body = body.Replace("#PuntuacionTotal#",Convert.ToString(PuntajePosible));
            //body = "El puntaje de la prueba " + this.PruebaPresentada.Nombre + " fué " + PuntajePrueba + "/" + PuntajePosible
            Util.Utilities.SendEmail(user.Email, body, true);
        }
        private void CalcularPuntajeCompetencia(ApplicationDbContext db, string idUser, int idCompetencia, int? PruebaId)
        { 

            //Todas las preguntas que pertenezcan a una prueba
            var preguntasPrueba = db.preguntas.Where(x => x.PruebaId == PruebaId).ToList();

            //Todas las preguntas de una prueba y una competencia
            ListaPreguntas = preguntasPrueba.Where(x => x.CompentenciaId == idCompetencia).ToList();

            //Opciones correctas en una competencia
            List<Opcion> opcionesCompetencia = new List<Opcion>();
            //calcula el puntaje posible de la prueba
            PuntajePosible = 0;
            PuntajePosible = (int) preguntasPrueba.Sum(x => x.PreguntaPeso);
            foreach(var i in ListaPreguntas)
            {
                opcionesCompetencia.Add(db.opciones.Where(x => x.PreguntaId == i.ID && x.Correcta).First());
            }
            PuntajePosibleCompetencia = (int) ListaPreguntas.Sum(x => x.PreguntaPeso);
            foreach (var i in preguntasPrueba)
            {
                OpcionesCorrectas.Add(db.opciones.Where(x => x.PreguntaId == i.ID && x.Correcta).First());
            }

            var respuestasEstudiante = db.preguntas_estudiantes.Where(x => x.User_Id == idUser).ToList();
            OpcionesRespondidas = respuestasEstudiante;
            //Puntaje de un alumno para toda la prueba
            PuntajePrueba = 0;
            foreach (var i in preguntasPrueba)
            {
                var IdOpcionCorrecta = OpcionesCorrectas.Where(x => x.PreguntaId == i.ID).First().ID;
                var IdOpcionMarcada = respuestasEstudiante.Where(x => x.PreguntaId == i.ID).First().OpcionId;

                if (IdOpcionCorrecta == IdOpcionMarcada)
                {
                    PuntajePrueba += (int)i.PreguntaPeso;
                }
            }
            //Puntaje de un alumno para una competencia
            PuntajeCompetencia = 0;
            foreach (var i in ListaPreguntas)
            {
                if (OpcionesCorrectas.Where(x => x.PreguntaId == i.ID).First().ID == respuestasEstudiante.Where(x => x.PreguntaId == i.ID).First().OpcionId)
                {
                    PuntajeCompetencia += (int) i.PreguntaPeso;
                }
            }
            foreach (var i in OpcionesRespondidas)
            {
                OpcionesMarcadasLabel.Add(i.ID, db.opciones.Where(x => x.ID == i.OpcionId).First());
            }
            
            
        }
        public CalificarPruebaViewModel(ApplicationDbContext db, int? PruebaId , string idUser, int idCompetencia)
        {
            CalcularPuntajeCompetencia(db, idUser, idCompetencia, PruebaId);
            CompetenciaActual = db.competencias.Find(idCompetencia);
            PruebaPresentada = db.pruebas.Find(PruebaId);
            CalcularPuntajePrueba(db, idUser);
        }
    }
}