using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Contexto")]
    public class Contexto
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        [StringLength(1024, ErrorMessage = "La descripción no puede tener más de 1024 caracteres")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public Estado Estado { get; set; }
    }
}