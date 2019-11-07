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
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                writer.Close();
                retorno = true;
            }catch(Exception innerException)
            {
                throw new ArchivosException(innerException);
            }
            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                retorno = true;
            }catch (Exception innerException)
            {
                throw new ArchivosException(innerException);
                /*
                datos = default(T);
                Console.WriteLine(innerException.Message);*/
            }
            return retorno;
        }
    }
}
