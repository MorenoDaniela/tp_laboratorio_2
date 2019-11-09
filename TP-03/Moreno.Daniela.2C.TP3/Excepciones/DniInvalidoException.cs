using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "FORMATO DE DNI INVALIDO";

        /// <summary>
        /// Utiliza al constructor de esta clase que recibe un mensaje.
        /// </summary>
        public DniInvalidoException()
            : this (DniInvalidoException.mensajeBase)
        {
            
        }

        /// <summary>
        /// Usa al constructor de esta clase que recibe un msj y una exception.
        /// </summary>
        /// <param name="e">Exception recibida.</param>
        public DniInvalidoException(Exception e)
            : this (DniInvalidoException.mensajeBase,e)
        {

        }

        /// <summary>
        /// Usa al constructor de la clase padre que recibe un string.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido</param>
        public DniInvalidoException(string mensaje)
            : base (mensaje)
        {
            
        }

        /// <summary>
        /// Usa al constructor de la clase padre que recibe un string y una exception.
        /// </summary>
        /// <param name="mensaje">msj recibido</param>
        /// <param name="e">exception recibida</param>
        public DniInvalidoException(string mensaje, Exception e)
            : base (mensaje,e)
        {

        }

    }
}
