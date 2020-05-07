using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Contexto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Estado_Habilitado { get; set; }
    }
}