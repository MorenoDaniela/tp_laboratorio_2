using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TrakingIdRepetidoException : Exception
    {
        public TrakingIdRepetidoException() : base ("El TrakingId que ha ingresado es repetido")
        {

        }

    }
}
