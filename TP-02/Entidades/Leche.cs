using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// La clase Leche hereda de la clase Producto.
    /// </summary>
    public class Leche : Producto
    {
        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Enumerados"
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será ENTERA. Crea un objeto Leche reutilizando el constructor de la clase padre Producto.
        /// </summary>
        /// <param name="marca">Marca de la leche. </param>
        /// <param name="patente">Codigo de la leche. </param>
        /// <param name="color">Color de la leche. </param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Crea un objeto Leche, reutiliza el constructor de arriba, con la diferencia que se puede especificar el tipo de leche.
        /// </summary>
        /// <param name="marca">Marca de la leche. </param>
        /// <param name="codigo"> Codigo de la leche. </param>
        /// <param name="color">Color de la leche. </param>
        /// <param name="tipo">tipo de la leche. </param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
           : this (marca,codigo,color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna todos los datos de un objeto Leche.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0} \n", this.CantidadCalorias);
            sb.AppendFormat("TIPO: {0}" ,this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
