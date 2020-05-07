using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Ciudad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Departamento")]
        public int Departamento_Id { get; set; }
        public Departamento Departamento { get; set; }
        
    }
}