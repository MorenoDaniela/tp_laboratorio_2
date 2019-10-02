using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias//protected decia en vez de public
        {
            get
            {
                //Producto.CantidadCalorias = 80;
                return 80;
            }
        }


        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base (codigo,marca,color)
        {
            
        }

      

        public override string Mostrar()//agregue public, saque sealed
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendFormat(base.Mostrar());//corregir
            sb.AppendFormat("\nCALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
