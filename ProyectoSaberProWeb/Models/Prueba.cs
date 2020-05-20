using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Prueba")]
    public class Prueba
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre de la prueba")]
        [StringLength(40, ErrorMessage = "El nombre no puede tener más de {0} caracteres")]
        public string Nombre { get; set; }
        [Required]
        [NonZeroValue]
        [Display(Name ="Cantidad de preguntas")]
        public int CantidadPreguntas {get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [Display(Name = "Estado de la prueba")]
        public Estado Estado { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        /*public Prueba()
        {
            this.FechaCreacion = DateTime.Now;
        }*/
    }
}