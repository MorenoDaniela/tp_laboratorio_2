using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido.
        /// </summary>
        /// <param name="operador">Recibe un operador string</param>
        /// <returns>Retorna el operador recibido, si el operador NO es - o / o * retorna por defecto +.</returns>
        private static string ValidarOperador(string operador)
        {
            string op = "+";
            if (operador == "-")
            {
                op = "-";
            }
            else if (operador == "/")
            {
                op = "/";
            }
            else if (operador == "*")
            {
                op = "*";
            }
            return op;
        }

        /// <summary>
        /// Opera entre dos objetos de tipo Numero.
        /// </summary>
        /// <param name="num1">Primer numero recibido</param>
        /// <param name="num2">Segundo numero recibido</param>
        /// <param name="operador">Operador en formato string</param>
        /// <returns>Retorna el resultado de la operacion, si alguno de los numeros recibidos es null retorna 0.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            if (num1 != null && num2 != null)
            {
                switch (ValidarOperador(operador))
                {
                    case "-":
                        retorno = num1 - num2;
                        break;
                    case "+":
                        retorno = num1 + num2;
                        break;
                    case "/":
                        retorno = num1 / num2;
                        break;
                    case "*":
                        retorno = num1 * num2;
                        break;
                }
            }
            return retorno;
        }

    }
}
