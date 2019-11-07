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
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            
            try
            {
                using (StreamWriter str = new StreamWriter(archivo, false))
                {
                    str.WriteLine(datos);
                    retorno = true;
                }
            }catch(Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
            
            return retorno;
        }

        public bool Leer (string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader str = null;
            try
            {
                using (str = new StreamReader(archivo))
                {
                    datos = str.ReadToEnd();
                    retorno = true;
                }
            }catch (Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
            return retorno;
        }
            
            
    }
}
