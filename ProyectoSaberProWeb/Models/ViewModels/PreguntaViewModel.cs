using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSaberProWeb.Models;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PreguntaViewModel
    {
        public Pregunta PreguntaCreacion { get; set; }
        public IEnumerable<Pregunta> ListaPreguntas { get; set; }
        public List<SelectListItem> ListaCompetencias { get; set; }
        public List<SelectListItem> ListaPruebas { get; set; }
        public List<SelectListItem> ListaContextos { get; set; }
        public Opcion OpcionA { get; set; }
        public Opcion OpcionB { get; set; }
        public Opcion OpcionC { get; set; }
        public Opcion OpcionD { get; set; }
        public List<Opcion> OpcionesCreacion { get; set; }
        public string Message { get; set; }
        private void instanceAll(ApplicationDbContext db)
        {
            PreguntaCreacion = new Pregunta();
            this.ListaPruebas = this.consultarPruebas(db);
            this.ListaContextos = this.consultarContextos(db);
            this.ListaCompetencias = this.consultarCompetencias(db);
            OpcionA = new Opcion() { Correcta = false};
            OpcionB = new Opcion() { Correcta = false };
            OpcionC = new Opcion() { Correcta = false };
            OpcionD = new Opcion() { Correcta = false };
            /*OpcionesCreacion.Add(OpcionA);
            OpcionesCreacion.Add(OpcionB);
            OpcionesCreacion.Add(OpcionC);
            OpcionesCreacion.Add(OpcionD);*/

        }
        public PreguntaViewModel(ApplicationDbContext db)
        {
            ListaPreguntas = db.preguntas.ToList();
            this.instanceAll(db);
            Message = null;
        }
        public PreguntaViewModel(ApplicationDbContext db, int? PruebaId)
        {
            ListaPreguntas = db.preguntas.Where(x => x.PruebaId == PruebaId).ToList();
            this.instanceAll(db);
            Message = null;
            
        }
        public PreguntaViewModel()
        {

        }

        private List<SelectListItem> consultarCompetencias(ApplicationDbContext db)
        {
            List<SelectListItem> ListaCompetencias = new List<SelectListItem>();
            foreach (var comp in db.competencias)
            {
                ListaCompetencias.Add(new SelectListItem() { Value = comp.ID.ToString(), Text = comp.Nombre });   
            }
            return ListaCompetencias;
        }
        private List<SelectListItem> consultarContextos(ApplicationDbContext db)
        {
            List<SelectListItem> ListaContextos = new List<SelectListItem>();
            foreach (var Contexto in db.contexto)
            {
                ListaContextos.Add(new SelectListItem() { Value = Contexto.ID.ToString(), Text = Contexto.Descripcion });
            }
            return ListaContextos;
        }
        private List<SelectListItem> consultarPruebas(ApplicationDbContext db)
        {
            List<SelectListItem> ListaPruebas = new List<SelectListItem>();
            foreach (var prueba in db.pruebas)
            {
                ListaPruebas.Add(new SelectListItem() { Value = prueba.ID.ToString(), Text = prueba.Nombre });
            }
            return ListaPruebas;
        }
    }
}