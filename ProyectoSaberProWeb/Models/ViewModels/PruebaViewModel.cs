using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PruebaViewModel
    {
        public Prueba PruebaCreacion { get; set; }
        public IEnumerable<Prueba> ListaPruebas { get; set; }
        public string Message { get; set; }

        public PruebaViewModel(){}
        public PruebaViewModel(ApplicationDbContext db)
        {
            PruebaCreacion = new Prueba();
            ListaPruebas = db.pruebas.ToList();
            Message = null;
        }
    }
}