using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Competencia")]
    public class Competencia
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(30, ErrorMessage = "La descripción no puede tener más de 30 caracteres")]
        public string Nombre { get; set; }
    }
}