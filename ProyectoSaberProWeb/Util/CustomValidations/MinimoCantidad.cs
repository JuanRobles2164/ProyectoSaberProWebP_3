using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb
{
    [AttributeUsage(AttributeTargets.Property 
        | AttributeTargets.Field 
        | AttributeTargets.Parameter, 
          AllowMultiple = false)]
    internal sealed class NonZeroValueAttribute : ValidationAttribute
    {
        private int Minimun = 1;
        public NonZeroValueAttribute(){}
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            var valInt = int.Parse(value.ToString());
            var min = (IComparable)this.Minimun;
            return min.CompareTo(valInt) <= 0;
        }
        public override string FormatErrorMessage(string name)
        {
            var msg = string.Format("El valor mínimo aceptado es {0}", this.Minimun);
            return msg;
        }
    }
}