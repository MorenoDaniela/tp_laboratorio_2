
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Convierte un objeto en memoria en una secuencia lineal de bytes. Retonar true si se logro serializar el objeto
        /// Lanza ArchivosException si no se logro.
        /// </summary>
        /// <param name="archivo">Path del archivo </param>
        /// <param name="datos">Tipo de objeto</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                writer.Close();
                return true;
            }catch(Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
        }

        /// <summary>
        /// Reconstruye un objeto mediante Deserializacion. Retorna true si se logra, lanza ArchivosExcepcion si no.
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Tipo de objeto</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }catch (Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
        }
    }
}
