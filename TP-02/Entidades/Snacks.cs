using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Snacks hereda de la clase Producto.
    /// </summary>
    public class Snacks : Producto
    {
        #region "Propiedades"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Crea un objeto Snacks reutlizando el constructor de la clase padre Producto.
        /// </summary>
        /// <param name="marca">Marca del snack. </param>
        /// <param name="codigo">Codigo del snack. </param>
        /// <param name="color">Color del snack. </param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {

        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna todos los datos de un Snack.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
