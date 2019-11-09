using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    /// <summary>
    /// Clase sellada Profesor, no puede heredar.
    /// </summary>
#pragma warning disable CS0660,CS0661
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Reutiliza constructor de la clase padre Universitario.
        /// </summary>
        public Profesor()
            : base()
        {
            
        }

        /// <summary>
        /// Constructor estatico, instancia el Random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Crea un objeto de tipo Profesor.
        /// </summary>
        /// <param name="id">ID del profesor</param>
        /// <param name="nombre">NOMBRE DEL PROFESOR</param>
        /// <param name="apellido">APELLIDO DEL PROFESOR</param>
        /// <param name="dni">DNI DEL PROFESOR</param>
        /// <param name="nacionalidad">NACIONALIDAD DEL PROFESOR</param>
        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            : base (id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Compara un profesor con una clase.
        /// </summary>
        /// <param name="i">Profesor recibido</param>
        /// <param name="clase">Clase recibida</param>
        /// <returns>Retorna true si el profesor puede dar la clase.</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            if (!(i is null))
            {
                foreach (EClases materia in i.clasesDelDia)
                {
                    if (materia == clase)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara un profesor con una clase.
        /// </summary>
        /// <param name="i">Profesor recibido</param>
        /// <param name="clase">Clase recibida</param>
        /// <returns>Retorna true si el profesor no puede dar la clase.</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region "Metodos"

        /// <summary>
        /// Invoca al metodo MostrarDatos de esta clase.
        /// </summary>
        /// <returns>Devuelve un string.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Implementacion del metodo ParticiparEnClase de la clase padre.
        /// </summary>
        /// <returns>Retorna las clases del dia que tiene un profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("CLASES DEL DIA: \r\n");
            foreach (EClases materia in this.clasesDelDia)
            {
                cadena.AppendFormat("{0}\r\n", materia.ToString());
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Sobreescritura del metodo MostrarDatos de la clase base, e invoca al metodo ParticiparEnClase de la clase padre.
        /// </summary>
        /// <returns>Retorna un string con todos los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0}{1}\r\n", base.MostrarDatos(), this.ParticiparEnClase());
            return cadena.ToString();
        }

        /// <summary>
        /// Le asigna a la lista clases del dia del profesor una clase a traves del Meotodo random.Next.
        /// </summary>
        void _randomClases()
        {
            int value;
            value = random.Next(0, 4);
            Thread.Sleep(300);
            EClases aux = (EClases)value;
            clasesDelDia.Enqueue(aux);            
        }

        #endregion
    }
}
