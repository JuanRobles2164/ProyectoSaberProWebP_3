using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoSaberProWeb.Models;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PreguntaViewModel
    {
        public Pregunta Pregunta { get; set; }
        public IEnumerable<Pregunta> Preguntas { get; set; }
        public string Message { get; set; }
        public PreguntaViewModel(ApplicationDbContext db)
        {
            
        }
        public PreguntaViewModel()
        {

        }
    }
}