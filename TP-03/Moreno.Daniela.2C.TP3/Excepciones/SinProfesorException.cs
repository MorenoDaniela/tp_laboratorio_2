using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Usa al constructor de la clase base que recibe un mensaje.
        /// </summary>
        public SinProfesorException()
            : base ("No hay profesor para la clase.")
        {

        }
    }
}
