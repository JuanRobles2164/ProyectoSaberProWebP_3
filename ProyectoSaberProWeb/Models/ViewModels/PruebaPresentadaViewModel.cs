using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PruebaPresentadaViewModel
    {
        public IEnumerable<Prueba_Estudiante> ListaPruebasPresentadas { get; set; }
        public Dictionary<int, Prueba> PruebasVista { get; set; }
        public Prueba PruebaLabel { get; set; }
        public int PruebaId { get; set; }
        public int CompetenciaId { get; set; }
        public List<SelectListItem> Competencias { get; set; }
        public PruebaPresentadaViewModel() { }
        public PruebaPresentadaViewModel(ApplicationDbContext db, string UserId)
        {
            ListaPruebasPresentadas = db.pruebas_estudiantes.Where(x => x.UserId == UserId).ToList();
            PruebasVista = new Dictionary<int, Prueba>();
            foreach (var i in ListaPruebasPresentadas)
            {
                PruebasVista.Add(i.ID, db.pruebas.Find(i.PruebaId));
            }
            PruebaLabel = new Prueba();
            Competencias = new List<SelectListItem>();
            foreach (var i in db.competencias.ToList())
            {
                Competencias.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre });
            }
        }
    }
}