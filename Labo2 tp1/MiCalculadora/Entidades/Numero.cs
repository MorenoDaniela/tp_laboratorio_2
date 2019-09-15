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
        public string SetNumero
        {
            //get { return numero; }
            set { numero = ValidarNumero(value); }
        }
        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNum)
        {
            //this.SetNumero = strNume;//revisar aca
            double.TryParse(strNum, out numero);
        }

        private double ValidarNumero(string strNum)
        {
            if (!double.TryParse(strNum, out double retorno))
            {
                retorno = 0;
            }
            return retorno;
        }

        public string DecimalBinario(double numero)
        { 
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
            #region harcode
            
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
            #endregion
        }

        public string DecimalBinario(string numero)
        // : this (string.Parse(numero))
        {
            string retorno = "Valor invàlido";
            if (double.TryParse(numero, out double doble))
            {
                Numero num = new Numero(doble);//revisar aca
                retorno = num.DecimalBinario(doble);
            }
            return retorno;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invàlido";
            long num = Convert.ToInt64(binario, 2);
            double numDecimal;

            if (double.TryParse(num.ToString(), out numDecimal))
            {
                retorno = numDecimal.ToString();
            }
            return retorno;

            #region hardcode
            /*
            string retorno = "Valor invàlido";
            char[] array = binario.ToCharArray();
            // Invertido pues los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(array);
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Usamos la potencia de 2, según la posición
                    sum += (int)Math.Pow(2, i);
                }
            }
            retorno = Convert.ToString(sum);
            return retorno;
            */
            #endregion

        }

        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

    }
}
