using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
#pragma warning disable CS0661, CS0659
    /// <summary>
    /// Clase abstracta que hereda de persona.
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region"Atributos"
        private int legajo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Reutiliza al constructor de la clase base.
        /// </summary>
        public Universitario()
            : base ()
        {

        }
        /// <summary>
        /// Crea un objeto de tipo Universitario, utiliza al constructor de la clase base.
        /// </summary>
        /// <param name="legajo">LEGAJO DEL UNIVERSITARIO</param>
        /// <param name="nombre">NOMBRE DEL UNIVERSITARIO</param>
        /// <param name="apellido">APELLIDO DEL UNIVERSITARIO</param>
        /// <param name="dni">DNI DEL UNIVERSITARIO</param>
        /// <param name="nacionalidad">NACIONALIDAD DEL UNIVERSITARIO</param>
        public Universitario(int legajo,string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            : base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region "Sobrecarga"
        /// <summary>
        /// Sobrecarga Equals, chequea si el objeto que recibe es un universitario.
        /// </summary>
        /// <param name="obj">OBJ a recibir</param>
        /// <returns>Retorna true si el objeto es universitario, false si no lo es.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (!(obj is null))
            {
                if (obj is Universitario)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Compara un universitario con otro, utiliza equals, y compara si sus dni son iguales o legajos.
        /// </summary>
        /// <param name="pg1">universitario recibido uno</param>
        /// <param name="pg2">universitario recibido dos</param>
        /// <returns>Retorna true si son iguales, false si no.</returns>
        public static bool operator==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (!(pg1 is null) && !(pg2 is null))
            {
                if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Reutiliza operador de arriba.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son diferentes, false si son iguales.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo a sobrescribir virtual.
        /// </summary>
        /// <returns>Retorna un string con los datos del universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0} \r\nLEGAJO NUMERO: {1} \r\n", base.ToString(),this.legajo);
            return cadena.ToString();
        }
        /// <summary>
        /// Metodo abstracto sin implementación.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

    }
}
