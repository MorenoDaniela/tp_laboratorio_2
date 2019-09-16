using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Asigna el valor recibido al atributo numero.
        /// </summary>
        public string SetNumero
        {
            //get { return numero; }
            set { numero = ValidarNumero(value); }
        }

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="numero">Recibe un double y lo asigna al atributo numero.</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor, valida el valor recibido en strNum-
        /// </summary>
        /// <param name="strNum">numero formato string a validar</param>
        public Numero(string strNum)
        {
            this.SetNumero = strNum;//double.TryParse(strNum, out numero);
        }
        #endregion 

        /// <summary>
        /// Valida que el numero ingresado se pueda parsear a double y lo devuelve en ese formato, caso contrario retorna 0.
        /// </summary>
        /// <param name="strNum">numero ingresado en string</param>
        /// <returns>Retorna 0 si la conversion no se puede hacer, el numero en formato double si fue exitosa.</returns>
        private double ValidarNumero(string strNum)
        {
            if (!double.TryParse(strNum, out double retorno))
            {
                retorno = 0;
            }
            return retorno;
        }

        #region CONVERSION
        /// <summary>
        /// Convierte un numero double decimal en formato string y binario.
        /// </summary>
        /// <param name="numero">recibe un numero decimal en formato double</param>
        /// <returns>Si la conversion es realizada con exito retorna el numero en formato string de forma binaria
        ///si la conversion no se puede hacer retorna "valor invàlido" en formato string/// </returns>
        public string DecimalBinario(double numero)
        {
            #region sin harcode
            /*
            string retorno = "Valor invàlido";
            if (numero >= 0)
            {
                string auxString = numero.ToString();
                Convert.ToInt64(auxString, 10);
                retorno = auxString.ToString();
            }
            return retorno;
            */
            #endregion
            int numAux = (int)numero;
            string retorno = "Valor invàlido";
            string aux = "";

            if (numAux > 0)
            {
                while (numAux > 1)
                {
                    if (numAux % 2 == 0)
                    {
                        aux = "0" + aux;
                        numAux = numAux / 2;
                    }
                    else
                    {
                        aux = "1" + aux;
                        numAux = numAux / 2;

                    }
                }

                if (numAux == 1)
                {
                    aux = "1" + aux;
                }
                retorno = aux;
            }
            return retorno;    
        }
        /// <summary>
        /// Convierte un numero decimal recibido en formato string a binario a traves de la reutilizacion de codigo
        /// sobrecarga de metodo, invoca al metodo DecimalBinario que recibe un double.
        /// </summary>
        /// <param name="numero">recibe un numero decimal en formato string</param>
        /// <returns>Retorna el numero binario en formato string si la conversion fue exitosa
        /// Valor invàlido si la conversion no fue exitosa.</returns>
        public string DecimalBinario(string numero)
        
        {
            string retorno = "Valor invàlido";
            if (double.TryParse(numero, out double doble))
            {
                Numero num = new Numero(doble);//revisar aca
                retorno = num.DecimalBinario(doble);
            }
            return retorno;
        }
        /// <summary>
        /// Transforma un numero binario en formato string a decimal.
        /// </summary>
        /// <param name="binario">Recibe un numero binario en formato string</param>
        /// <returns>Retorna cadena invalida si la conversion no fue exitosa, retorna el numero binario en formato string 
        /// ya convertido a decimal</returns>
        public string BinarioDecimal(string binario)
        {
            #region sin hardcode
            /*
            string retorno = "Valor invàlido";
            if (binario== "Valor invàlido")
            {
                return retorno;
            }
            else
            {
                long num = Convert.ToInt64(binario, 2);//En el caso de que el numero no sea binario devuelve una excepcion

                double numDecimal;
                if (num != 0)
                {
                    if (double.TryParse(num.ToString(), out numDecimal))
                    {
                        retorno = numDecimal.ToString();
                    }

                }else
                {
                    retorno = "Valor invàlido";
                }
            }
           
            return retorno;
            */
            #endregion

            string retorno = "Valor invàlido";
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            int numero = 0;
            int i;

            for (i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    numero += (int)Math.Pow(2, i);
                }else if (array[i]!= '1' && array[i]!='0')
                {
                    return retorno;
                }
            }
            retorno = Convert.ToString(numero);
            return retorno;
        }

        #endregion

        #region OPERADORES/SOBRECARGA
        /// <summary>
        /// Define el operador - para dos objetos de tipo numero.
        /// </summary>
        /// <param name="n1">Objeto numero1 recibido</param>
        /// <param name="n2">objeto numero2 recibido</param>
        /// <returns>Retorna la operacion entre esos dos numeros en formato double.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Define el operador + para dos objetos de tipo numero.
        /// </summary>
        /// <param name="n1">Objeto numero1 recibido</param>
        /// <param name="n2">objeto numero2 recibido</param>
        /// <returns>Retorna la operacion entre esos dos numeros en formato double.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Define el operador * para dos objetos de tipo numero.
        /// </summary>
        /// <param name="n1">Objeto numero1 recibido</param>
        /// <param name="n2">objeto numero2 recibido</param>
        /// <returns>Retorna la operacion entre esos dos numeros en formato double.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Define el operador / para dos objetos de tipo numero.
        /// </summary>
        /// <param name="n1">Objeto numero1 recibido</param>
        /// <param name="n2">objeto numero2 recibido</param>
        /// <returns>Retorna la operacion entre esos dos numeros en formato double en caso de ser posible, si el atributo numero del Numero n2
        /// es 0 retorna double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

        #endregion

    }
}
