﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI INVALIDO";

        public DniInvalidoException()
            : this (DniInvalidoException.mensajeBase)
        {
            
        }

        public DniInvalidoException(Exception e)
            : this (DniInvalidoException.mensajeBase,e)
        {

        }

        public DniInvalidoException(string mensaje)
            : base (mensaje)
        {
            
        }

        public DniInvalidoException(string mensaje, Exception e)
            : base (mensaje,e)
        {

        }

    }
}
