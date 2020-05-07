using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Pregunta_Estudiante
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("Pregunta")]
        public int Id_Pregunta { get; set; }
        public Pregunta Pregunta { get; set; }

        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}