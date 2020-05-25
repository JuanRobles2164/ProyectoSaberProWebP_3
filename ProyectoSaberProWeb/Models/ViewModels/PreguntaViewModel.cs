using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoSaberProWeb.Models;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PreguntaViewModel
    {
        public Pregunta PreguntaCreacion { get; set; }
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        public IEnumerable<Competencia> ListaCompetencias { get; set; }
        public IEnumerable<Prueba> ListaPruebas { get; set; }
        public IEnumerable<Contexto> ListaContextos { get; set; }
        public Opcion OpcionA { get; set; }
        public Opcion OpcionB { get; set; }
        public Opcion OpcionC { get; set; }
        public Opcion OpcionD { get; set; }
        public string Message { get; set; }
        public PreguntaViewModel(ApplicationDbContext db)
        {
            ListaPreguntas = db.preguntas.ToList();
            ListaPruebas = db.pruebas.ToList();
            ListaContextos = db.contexto.ToList();
            PreguntaCreacion = new Pregunta();
            OpcionA = new Opcion();
            OpcionB = new Opcion();
            OpcionC = new Opcion();
            OpcionD = new Opcion();
            Message = null;
        }
        public PreguntaViewModel(ApplicationDbContext db, int? PruebaId)
        {
            ListaPreguntas = db.preguntas.Where(x => x.PruebaId == PruebaId).ToList();
            ListaPruebas = db.pruebas.ToList();
            ListaContextos = db.contexto.ToList();
            PreguntaCreacion = new Pregunta();
            OpcionA = new Opcion();
            OpcionB = new Opcion();
            OpcionC = new Opcion();
            OpcionD = new Opcion();
            Message = null;
        }
        public PreguntaViewModel()
        {

        }
    }
}