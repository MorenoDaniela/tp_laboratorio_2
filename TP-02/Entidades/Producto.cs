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
    public abstract class Producto
    {
        #region "Atributos"
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region "Enumerados"
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }
        #endregion

        #region "Constructores"
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Producto. Este metodo es virtual porque sera sobrescrito en las clases hijas.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Marca: {0} \n\r" ,this.marca);
            cadena.AppendFormat("Codigo de barras: {0} \n\r" ,this.codigoDeBarras);
            cadena.AppendFormat("Color: {0} " ,this.colorPrimarioEmpaque);
            return cadena.ToString();
        }
        #endregion

        #region "Operadores"

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="producto2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            bool retorno = false;
            if (!(producto1 is null) && !(producto2 is null))
            {
                if (producto1.codigoDeBarras == producto2.codigoDeBarras)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1.codigoDeBarras == producto2.codigoDeBarras);
        }

        #endregion

        #region "Casteo"
        /// <summary>
        /// Devuelve un string con todos los datos del producto recibido, invoca al metodo Mostrar.
        /// </summary>
        /// <param name="p">Producto recibido.</param>
        public static explicit operator string(Producto p)
        {
            return p.Mostrar();
        }
        #endregion
    }
}
