using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class EstudianteViewModel
    {
        public Competencia CompetenciaLabels { get; set; }
        public Prueba PruebaLabels { get; set; }
        public IEnumerable<Competencia> ListaCompetencias { get; set; }
        public IEnumerable<Prueba> ListaPruebas { get; set; }
        private int competenciaActualId { get; set; }
        private int competenciaSiguienteId { get; set; }
        private int competenciaAnteriorId { get; set; }
        private void setAllData()
        {
            CompetenciaLabels = new Competencia();
            PruebaLabels = new Prueba();
        }
        private void setAllData(ApplicationDbContext db)
        {
            ListaPruebas = db.pruebas.Where(x => x.Estado == Estado.Activo);
            ListaCompetencias = db.competencias.ToList();
            CompetenciaLabels = new Competencia();
            PruebaLabels = new Prueba();
        }
        public EstudianteViewModel() { }
        public EstudianteViewModel(ApplicationDbContext db)
        {
            setAllData(db);
        }
        public EstudianteViewModel(ApplicationDbContext db, int CompetenciaId, int PruebaId)
        {

        }
    }
}
