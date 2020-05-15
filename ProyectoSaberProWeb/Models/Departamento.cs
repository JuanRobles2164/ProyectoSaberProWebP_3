using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}