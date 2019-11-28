using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
   public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string aux = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                using (StreamWriter str = new StreamWriter(aux + "\\" + archivo, File.Exists(archivo)))
                {
                    str.WriteLine(texto);
                    retorno = true;
                }
            }catch (Exception e)
            {
                throw new Exception("Error al guardar en salidad.txt", e);
            }
           
            return retorno;
        }
    }
}
