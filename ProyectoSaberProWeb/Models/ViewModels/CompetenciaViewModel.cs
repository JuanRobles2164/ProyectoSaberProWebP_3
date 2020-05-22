using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class CompetenciaViewModel
    {
        public IEnumerable<Competencia> ListaCompetencias { get; set; }
        public Competencia CompetenciaCreacion { get; set; }
        public Competencia CompetenciaEdicion { get; set; }
        public string Message { get; set; }
        public CompetenciaViewModel() { }
        public CompetenciaViewModel(ApplicationDbContext db)
        {
            ListaCompetencias = db.competencias.ToList();
            CompetenciaCreacion = new Competencia();
            Message = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">ApplicationDbContext</param>
        /// <param name="id">int</param>
        public CompetenciaViewModel(ApplicationDbContext db, int id)
        {
            CompetenciaEdicion = db.competencias.Find(id);
        }

    }
}