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
    internal sealed class NonZeroValueFloatAttribute : ValidationAttribute
    {
        private float Minimun = 0.1f;
        public NonZeroValueFloatAttribute() { }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            var val = value as string;
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            var min = (IComparable)this.Minimun;
            return min.CompareTo(val) <= 0.0f;
        }
        public override string FormatErrorMessage(string name)
        {
            var msg = string.Format("El valor mínimo aceptado es {0}", this.Minimun);
            return msg;
        }
    }
}