using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Prueba_Estudiante")]
    public class Prueba_Estudiante
    {
        public int ID { get; set; }
        [Required]
        public DateTime FechaPresentacion { get; private set; }
        [Required]
        public Prueba Prueba { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Prueba_Estudiante() 
        {
            FechaPresentacion = DateTime.Now;
        }
    }
}