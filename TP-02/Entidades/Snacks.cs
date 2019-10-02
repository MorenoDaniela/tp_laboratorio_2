using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Snacks : Producto
    {
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {

        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias//cambie protected por public
        {
            get
            {
                return 104;
            }
        }

        public override string Mostrar()//saque sealead
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
