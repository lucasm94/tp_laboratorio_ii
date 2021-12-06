using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Extensión del tipo DateTime, que devuelve un bool si es mayor o no.
        /// </summary>
        public static bool EsMayor(this DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            return edad > 17;
        }
    }
}
