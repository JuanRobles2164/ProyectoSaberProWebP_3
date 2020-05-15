using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Opcion")]
    public class Opcion
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Descripción de la opción")]
        [StringLength(255, ErrorMessage = "La opción puede tener un máximo de 255 caracteres")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name ="¿Correcta?")]
        public bool Correcta { get; set; }

        /*---------------------------------------*/
        [ForeignKey("Pregunta")]
        [Display(Name ="Pregunta a la que pertenece")]
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}