using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
#pragma warning disable CS0661,CS0660
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto//no puede ser sealed porque las clases sealed no heredan, saque sealed,
        //ademas el dibujo decia que la clase es abstracta
    {
        public enum EMarca//aca agregue public
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
        protected EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadCalorias//aca agregue public 
        {
            get;
            //set;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()//aca era sealed, agregue virtual porque los metodos virtuales se sobrescriben con override en las clases hijas
        {

            //return (string)this.ToString();
            return (string)this;
            //return this.ToString();
            /*
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Marca: {0} \n\r" ,this.marca);
            cadena.AppendFormat("Codigo de barras: {0} \n\r" ,this.codigoDeBarras);
            cadena.AppendFormat("Color: {0} \n\r" ,this.colorPrimarioEmpaque);
            return cadena.ToString();*/
            //return this;*/
        }

        
        public static explicit operator string(Producto p)//firma original private static explicit operator string
        {
            //return p.Mostrar();
            
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0} \n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
            if (!(v1 is null) && !(v2 is null))
            {
                if (v1.codigoDeBarras == v2.codigoDeBarras)
                {
                    retorno = true;
                }
            }
            return retorno;
            //return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            
            bool retorno = true;
            if (v1==v2)
            {
                retorno = false;
            }
            return retorno;
            //return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        public Producto (string codigo, EMarca marcaE, ConsoleColor color)//agregue este constructor faltaba
        {
            this.codigoDeBarras = codigo;
            this. marca = marcaE;
            this.colorPrimarioEmpaque = color;
        }
    }
}
