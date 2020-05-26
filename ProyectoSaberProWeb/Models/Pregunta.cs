using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Pregunta")]
    public class Pregunta
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Descripción de la pregunta")]
        [StringLength(255, ErrorMessage = "La descripción no puede tener más de 255 caracteres")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name ="Tipo de pregunta")]

        public TipoPregunta TipoPregunta { get; set; }
        [Required]
        [Display(Name = "Peso de la pregunta")]
        public float PreguntaPeso { get; set; }

        /*----------------------------------------*/
        [ForeignKey("Competencia")]
        [Display(Name ="Competencia a la que pertenece")]
        public int CompentenciaId { get; set; }
        public Competencia Competencia { get; set; }
        /*----------------------------------------*/
        [ForeignKey("Contexto")]
        [Display(Name ="Contexto al que pertenece")]
        public int ContextoId { get; set; }
        public Contexto Contexto { get; set; }
        /*----------------------------------------*/
        [ForeignKey("Prueba")]
        [Display(Name ="Prueba a la que pertenece")]
        public int PruebaId { get; set; }
        public Prueba Prueba { get; set; }
    }
}