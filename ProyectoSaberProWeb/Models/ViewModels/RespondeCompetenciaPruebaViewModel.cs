using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class RespondeCompetenciaPruebaViewModel
    {
        public Competencia CompetenciaPresentando { get; set; }
        public Prueba PruebaPresentando { get; set; }
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        public Dictionary<int, IEnumerable<Opcion>> OpcionesPregunta { get; set; }
        public IEnumerable<Opcion> ListaOpciones { get; set; }
        public string Message { get; set; }

        public RespondeCompetenciaPruebaViewModel() { }
        public RespondeCompetenciaPruebaViewModel(ApplicationDbContext db)
        {
            ListaPreguntas = db.preguntas.ToList();
            OpcionesPregunta = new Dictionary<int, IEnumerable<Opcion>>();
            foreach (var i in ListaPreguntas)
            {
                IEnumerable<Opcion> opciones = db.opciones.Where(x => x.PreguntaId == i.ID);
                OpcionesPregunta.Add(i.ID, opciones);
            }
        }
        public RespondeCompetenciaPruebaViewModel(ApplicationDbContext db, int CompetenciaId, int PruebaId)
        {
            CompetenciaPresentando = db.competencias.Find(CompetenciaId);
            PruebaPresentando = db.pruebas.Find(PruebaId);
            /*ListaPreguntas = from preguntas in db.preguntas
                             join pruebas in db.pruebas
                             on preguntas.PruebaId equals pruebas.ID
                             
                             from preguntas2 in db.preguntas
                             join competencias in db.competencias
                             on preguntas2.CompentenciaId equals competencias.ID

                             where preguntas.PruebaId == PruebaId && preguntas2.CompentenciaId == CompetenciaId
                             select preguntas;
            */
            //ListaPreguntas = db.opciones.Include("Pregunta").Include("Prueba").Include("Contexto");
            var numerito = 1;
            if (numerito == 1)
            {
                Console.WriteLine("funciona");
            }
        }
    }
}