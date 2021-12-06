using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que se lanzara si existe algun problema al leer/guardar archivos
    /// </summary>
    public class ArchivosException :Exception
    {
        public ArchivosException(Exception innerException) : this("Error con el archivo" ,innerException)
        {

        }

        public ArchivosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

    }
}