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
        public Competencia Competencia { get; set; }
        public int PuntajeCompetencia { get; set; }
        public int PuntajePosible { get; set; }
        public List<Pregunta> ListaPreguntas { get; set; } = new List<Pregunta>(); 
        public List<Opcion> OpcionesCorrectas { get; set; } = new List<Opcion>();
        public List<Pregunta_Estudiante> OpcionesRespondidas { get; set; } = new List<Pregunta_Estudiante>();

        /// <summary>
        /// Diccionario para saber si el estudiante respondio correctamente la pregunta Dictionary <int (pregunta), int (opcion)>
        /// </summary>
        public void CalcularPuntajePrueba()
        {
            //suma de los puntajes de las competencias (esto podria mandarse por correo)
        }
        public CalificarPruebaViewModel(ApplicationDbContext db, int? PruebaId , string idUser, int idCompetencia)
        {
            
            Dictionary<int, int> OpcionC = new Dictionary<int, int>();
            List<int> OR = new List<int>();
            int OpcionesR;
            int OpcionesC;
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
        }
    }
}