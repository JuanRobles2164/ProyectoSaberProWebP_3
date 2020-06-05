using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class ResultadosViewModel
    {
        public IEnumerable<Prueba> ListaPruebas { get; set; }
        public float Resultado { get; set; }
        public float MaximoPosible { get; set; }
        public Prueba PruebaPresentada { get; set; }
        public ResultadosViewModel() { }
        public ResultadosViewModel(ApplicationDbContext db, int PruebaId, string UserId) 
        {
            MaximoPosible = 0.0f;
            Resultado = 0.0f;
            PruebaPresentada = db.pruebas.Find(PruebaId);
            var Preguntas = db.preguntas.Where(x => x.PruebaId == PruebaPresentada.ID);

            //PreguntaId, OpcionCorrecta
            Dictionary<int, Opcion> OpcionesCorrectas = new Dictionary<int, Opcion>();
            foreach (var i in Preguntas)
            {
                MaximoPosible += i.PreguntaPeso;
                //Opcion correcta de una pregunta
                OpcionesCorrectas.Add(i.ID, db.opciones.Where(x => x.PreguntaId == i.ID && x.Correcta).First());
            }
            //Respuestas del estudiante
            var Respuestas = db.preguntas_estudiantes.Where(x => x.User_Id == UserId).ToList();

            //Calcula la sumatoria de las respuestas correctas
            foreach (var i in Respuestas)
            {
                if (i.OpcionId == OpcionesCorrectas[i.ID].ID)
                {
                    Resultado += i.Pregunta.PreguntaPeso;
                }
            }
        }
    }
}