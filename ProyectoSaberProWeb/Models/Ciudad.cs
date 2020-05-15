using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Departamento")]
        [Display(Name = "Departamento")]
        public int Departamento_Id { get; set; }
        public Departamento Departamento { get; set; }
        
    }
}