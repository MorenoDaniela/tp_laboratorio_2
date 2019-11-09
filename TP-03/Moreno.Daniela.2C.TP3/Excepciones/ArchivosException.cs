using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Usa al constructor de la clase base que resibe una excepcion y un mensaje.
        /// </summary>
        /// <param name="innerException">Exception recibida.</param>
        public ArchivosException(Exception innerException)
            : base ("Archivos Exception",innerException)
        {

        }
    }
}
