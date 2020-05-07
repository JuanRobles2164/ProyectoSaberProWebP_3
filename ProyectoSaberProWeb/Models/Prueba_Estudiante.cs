using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Prueba_Estudiante
    {
        public int ID { get; set; }
        public DateTime Fecha_Presentacion { get; set; }

        public Prueba Prueba { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}