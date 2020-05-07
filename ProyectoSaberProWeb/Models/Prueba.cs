using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Prueba
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Preguntas {get; set;}
        public DateTime Fecha_Creacion { get; set; }
        public bool Estado_Habilitada { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}