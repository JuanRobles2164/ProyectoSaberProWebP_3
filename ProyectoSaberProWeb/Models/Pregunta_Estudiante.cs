using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Pregunta_Estudiante")]
    public class Pregunta_Estudiante
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [StringLength(255, ErrorMessage = "La descripción no puede tener más de 255 caracteres")]
        public string Descripcion { get; set; }

        [ForeignKey("Pregunta")]
        public int Pregunta_Id { get; set; }
        public Pregunta Pregunta { get; set; }

        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}