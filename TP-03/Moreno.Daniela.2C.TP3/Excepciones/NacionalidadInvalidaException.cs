using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Usa al constructor de esta clase.
        /// </summary>
        public NacionalidadInvalidaException()
            : this ("La nacionalidad no se condice con el numero de DNI.")
        {

        }
        /// <summary>
        /// Usa al constructor de la clase base.
        /// </summary>
        /// <param name="message">mensaje recibido.</param>
        public NacionalidadInvalidaException(string message)
            : base (message)
        {

        }
    }
}
