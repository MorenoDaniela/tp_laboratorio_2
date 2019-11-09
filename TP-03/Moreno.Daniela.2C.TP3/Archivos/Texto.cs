using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de texto.
        /// </summary>
        /// <param name="archivo">PATH RECIBIDO</param>
        /// <param name="datos">DATOS RECIBIDOS</param>
        /// <returns>Retorna true si logro guardar los datos, lanza una exception si no.</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter str = new StreamWriter(archivo, File.Exists(archivo)))
                {
                    str.WriteLine(datos);
                    return true;
                }
            }catch(Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
            
        }

        /// <summary>
        /// Lee los datos de un archivo de texto.
        /// </summary>
        /// <param name="archivo">PATH RECIBIDO.</param>
        /// <param name="datos">Datos recibidos.</param>
        /// <returns>Retorna true si logro leer, lanza una exception sino.</returns>
        public bool Leer (string archivo, out string datos)
        {
            StreamReader str = null;
            try
            {
                using (str = new StreamReader(archivo,File.Exists(archivo)))
                {
                    datos = str.ReadToEnd();
                    return true;
                }
            }catch (Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
        }
            
            
    }
}
