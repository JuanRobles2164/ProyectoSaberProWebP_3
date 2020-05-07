using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public class Pregunta
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Pregunta { get; set; }
        public float Peso_Pregunta { get; set; }

        /*----------------------------------------*/
        [ForeignKey("Competencia")]
        public int Compentencia_Id { get; set; }
        public Competencia Competencia { get; set; }
        /*----------------------------------------*/
        [ForeignKey("Contexto")]
        public int Contexto_Id { get; set; }
        public Contexto Contexto { get; set; }
        /*----------------------------------------*/
        [ForeignKey("Prueba")]
        public int Prueba_Id { get; set; }
        public Prueba Prueba { get; set; }
    }
}