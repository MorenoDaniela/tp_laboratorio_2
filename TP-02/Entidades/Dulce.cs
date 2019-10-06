using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Dulce hereda de la clase Producto.
    /// </summary>
    public class Dulce : Producto
    {
        #region "Propiedades"
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Crea un objeto de tipo dulce reutilizando el constructor de la clase padre Producto.
        /// </summary>
        /// <param name="marca">Marca del dulce. </param>
        /// <param name="codigo">Codigo del dulce. </param>
        /// <param name="color">color del dulce. </param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base (codigo,marca,color)
        {
            
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna todos los datos de un Dulce.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("\nCALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
