using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T> 
    {
        /// <summary>
        /// Metodo sin implementacion, interfaz.
        /// </summary>
        /// <param name="archivo">path a recibir</param>
        /// <param name="datos">datos a recibir</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Metodo sin implementacion
        /// </summary>
        /// <param name="archivo">path a recibir</param>
        /// <param name="datos">datos a recibir</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
