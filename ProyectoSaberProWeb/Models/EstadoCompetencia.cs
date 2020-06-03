using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models
{
    public enum EstadoCompetencia
    {
        [Description("Presentada")]
        Presentada = 1,
        [Description("Sin Responder")]
        SinResponder = 2
    }
}