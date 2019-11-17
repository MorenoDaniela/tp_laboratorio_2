using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {

            conexion = new SqlConnection(AppDomain.CurrentDomain.BaseDirectory + "DatosPaquetes");
            conexion.Open();
        }
        public static bool InsertarPaquete(Paquete p)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("CREATE TABLE DatosPaquetes(Estado CHAR, ID CHAR, DIRECCION CHAR)");
            comando = new SqlCommand(cadena.ToString(), conexion);
            comando.ExecuteNonQuery();
        }
        
        

    }
}
