using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class RespondeCompetenciaPruebaViewModel
    {
        /// <summary>
        /// Obtiene el contexto que le pertenece a una pregunta
        /// </summary>
        public Dictionary<int, Contexto> PreguntaContexto { get; set; }

        /// <summary>
        /// Para seleccionar por cual competencia quiere empezar
        /// </summary>
        public List<SelectListItem> ListaCompetencias { get; set; }
        /// <summary>
        /// Seleccionar la prueba por la que quiere empezar
        /// </summary>
        public List<SelectListItem> ListaPruebas { get; set; }
        /// <summary>
        /// La competencia que actualmente presenta
        /// </summary>
        public Competencia CompetenciaPresentando { get; set; }
        /// <summary>
        /// La prueba que actualmente está presentando
        /// </summary>
        public Prueba PruebaPresentando { get; set; }
        /// <summary>
        /// La lista de preguntas de la actual pantalla
        /// </summary>
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        /// <summary>
        /// El int representa al id de la pregunta a la que le corresponden esas opciones
        /// </summary>
        
        public int SiguienteCompetencia { get; set; }
        public Dictionary<int, IEnumerable<Opcion>> OpcionesPregunta { get; set; }
        public string Message { get; set; }
        private void determinaSiguienteCompetencia(ApplicationDbContext db, int CompetenciaActual)
        {

        }
        private void initializeData(ApplicationDbContext db) 
        {
            OpcionesPregunta = new Dictionary<int, IEnumerable<Opcion>>();
            PreguntaContexto = new Dictionary<int, Contexto>();
            foreach (var i in ListaPreguntas)
            {
                IEnumerable<Opcion> opciones = db.opciones.Where(x => x.PreguntaId == i.ID).ToList();
                OpcionesPregunta.Add(i.ID, opciones);
            }
            foreach (var i in ListaPreguntas)
            {
                var ContextoVar = db.contexto.Find(i.ContextoId);
                PreguntaContexto.Add(i.ID, ContextoVar);
            }
        }
        public RespondeCompetenciaPruebaViewModel() { }
        /// <summary>
        /// Constructor sólo con el Db
        /// Es para cuando el estudiante vaya a escoger cuál prueba y 
        /// </summary>
        /// <param name="db"></param>
        public RespondeCompetenciaPruebaViewModel(ApplicationDbContext db)
        {
            ListaCompetencias = new List<SelectListItem>();
            ListaPruebas = new List<SelectListItem>();
            foreach (var i in db.competencias.ToList())
            {
                ListaCompetencias.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre});
            }
            foreach (var i in db.pruebas.ToList())
            {
                ListaPruebas.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre});
            }
        }
        /// <summary>
        /// Constructor cuando le llega el db, la competencia que se va a responder y la prueba
        /// Básicamente cuando va a responder la prueba por primera vez
        /// </summary>
        /// <param name="db">ApplicationDbContext</param>
        /// <param name="CompetenciaId">Competencia a responder</param>
        /// <param name="PruebaId">Prueba a responder</param>
        public RespondeCompetenciaPruebaViewModel(ApplicationDbContext db, int CompetenciaId, int PruebaId)
        {
            CompetenciaPresentando = db.competencias.Find(CompetenciaId);
            PruebaPresentando = db.pruebas.Find(PruebaId);
            ListaPreguntas = db.preguntas.Where(x => x.CompentenciaId == CompetenciaPresentando.ID).ToList();
            ListaPreguntas = db.preguntas.Where(x => x.CompentenciaId == CompetenciaPresentando.ID).ToList();
            initializeData(db);
        }
    }
}