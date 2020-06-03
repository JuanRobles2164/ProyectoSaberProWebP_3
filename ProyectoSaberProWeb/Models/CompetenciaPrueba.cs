using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("CompetenciaPrueba")]
    public class CompetenciaPrueba
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public EstadoCompetencia Estado { get; set; }
        [Required]
        [ForeignKey("Competencia")]
        [Display(Name = "Competencia completada")]
        public int CompetenciaId { get; set; }
        public virtual Competencia Competencia { get; set; }
        [Required]
        [ForeignKey("User")]
        [Display(Name = "Estudiante que presento")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        [Required]
        [ForeignKey("Prueba")]
        [Display(Name = "Prueba a la que pertenece")]
        public int PruebaId { get; set; }
        public virtual Prueba Prueba { get; set; }
    }

}