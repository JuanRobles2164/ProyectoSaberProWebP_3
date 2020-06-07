using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoSaberProWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class CalificarPruebaViewModel
    {
        public int PuntajePrueba { get; set; }
        public Competencia CompetenciaActual { get; set; }
        public Prueba PruebaPresentada { get; set; } = new Prueba();
        public int PuntajeCompetencia { get; set; }
        public int PuntajePosible { get; set; }
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        public List<Opcion> OpcionesCorrectas { get; set; } = new List<Opcion>();
        public List<Pregunta_Estudiante> OpcionesRespondidas { get; set; } = new List<Pregunta_Estudiante>();

        /// <summary>
        /// Diccionario para saber si el estudiante respondio correctamente la pregunta Dictionary <int (pregunta), int (opcion)>
        /// </summary>
        public void CalcularPuntajePrueba(ApplicationDbContext db, string idUser)
        {
            var i = OpcionesCorrectas.GetEnumerator();
            var j = OpcionesRespondidas.GetEnumerator();
            var k = ListaPreguntas.GetEnumerator();
            while (i.MoveNext() && j.MoveNext() && k.MoveNext())
            {
                if (i.Current.ID == j.Current.OpcionId)
                {
                    PuntajePrueba += (int) k.Current.PreguntaPeso;
                }
            }
            var user = db.Users.Find(idUser);
            string body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("Estudiante/BodyCuerpoMsg.cshtml"));
            body = body.Replace("#Nombre de la prueba#", PruebaPresentada.Nombre);
            body = body.Replace("#PuntuacionSacada#",Convert.ToString(PuntajePrueba));
            body = body.Replace("#PuntuacionTotal#",Convert.ToString(PuntajePosible));
            //body = "El puntaje de la prueba " + this.PruebaPresentada.Nombre + " fué " + PuntajePrueba + "/" + PuntajePosible
            Util.Utilities.SendEmail(user.Email, body, true);
        }
        public CalificarPruebaViewModel(ApplicationDbContext db, int? PruebaId , string idUser, int idCompetencia)
        {
            
            Dictionary<int, int> OpcionC = new Dictionary<int, int>();
            List<int> OR = new List<int>();
            int OpcionesR;
            int OpcionesC;
            CompetenciaActual = db.competencias.Find(idCompetencia);
            PruebaPresentada = db.pruebas.Find(PruebaId);
            ListaPreguntas = db.preguntas.Where(a => a.PruebaId == PruebaId && a.CompentenciaId == idCompetencia).ToList();
            foreach(var p in ListaPreguntas)
            {
                OpcionesC =  (int) db.opciones.Where(a => a.Correcta == true && a.PreguntaId == p.ID).Select(a => a.ID).First();
                OpcionesCorrectas.Add(db.opciones.Where(a => a.Correcta == true && a.PreguntaId == p.ID).First());
                OpcionC.Add(p.ID, OpcionesC);
                OpcionesR =(int) db.preguntas_estudiantes.Where(a => a.User_Id == idUser && a.PreguntaId == p.ID).Select(a => a.OpcionId).First();
                OpcionesRespondidas.Add(db.preguntas_estudiantes.Where(a => a.User_Id == idUser && a.PreguntaId == p.ID).First());
                OR.Add(OpcionesR);
                foreach (var Or in OR)
                {
                    int PesoPregunta = (int)db.preguntas.Where(a => a.ID == p.ID).Select(a => a.PreguntaPeso).FirstOrDefault();
                    if (OpcionC[p.ID] == Or)
                    {
                        PuntajeCompetencia += PesoPregunta;
                    }
                    PuntajePosible += PesoPregunta;
                }
            }
            CalcularPuntajePrueba(db, idUser);
        }
    }
}