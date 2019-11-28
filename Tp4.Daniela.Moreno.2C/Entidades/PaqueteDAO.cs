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

            conexion = new SqlConnection(@"Data Source=DELL-PC\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
           
        }
        public static bool InsertarPaquete(Paquete p)
        {
            //bool retorno = false;//mirar retornos quedaron feos y analizar si tirar exceptionci
            try
            {
                conexion.Open();
                StringBuilder cadena = new StringBuilder();
                cadena.AppendFormat("INSERT INTO Paquetes VALUES('{0}', '{1}', 'Daniela Moreno')", p.DireccionEntrega, p.TrakingID);
                comando = new SqlCommand(cadena.ToString(), conexion);
                comando.ExecuteNonQuery();
                //conexion.Close();
                return true;
            }catch (Exception inner)
            {
                throw new Exception("Error en base de datos", inner);
            }
            finally
            {
                conexion.Close();
            }
          //  return retorno;
            
        }
        
        

    }
}
