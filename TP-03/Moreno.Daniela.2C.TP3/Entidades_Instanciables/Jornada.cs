using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using Archivos;
using Excepciones;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
#pragma warning disable CS0660,CS0661
    /// <summary>
    /// Clase Jornada.
    /// </summary>
    public class Jornada
    {
        #region "Atributos"
        private List<Alumno> alumnos;
        private EClases clases;
        private Profesor instructor;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que reutiliza al constructor privado de esta misma clase y ademas asigna la clase y el profesor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clases = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Retorna la lista de alumnos o setea la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set 
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Retorna el profesor de esta jornada o lo setea.
        /// </summary>
        public Profesor Instructores
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Retorna la clase de esta jornada o la setea.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clases;
            }
            set
            {
                this.clases = value;
            }
        }

        #endregion
        
        #region "Operadores"
        /// <summary>
        /// Compara una jornada con un alumno, devuelve true si ese alumno toma la clase de esa jornada.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return !(a != j.clases);
        }
        /// <summary>
        ///Compara una jornada con un alumno, retorna true si ese alumno NO toma la clase de esa jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Retorna una jornada con el alumno agregado a la lista de alumnos de una jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null) && !(a is null))
            {
                if (j!=a)
                {
                    j.Alumnos.Add(a);
                }
            }
            return j;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Invoca al metodo Guardar de la clase Texto. 
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>Retorna true si logro guardarse la jornada, false si no.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            IArchivo<string> archivosTexto = new Texto();
            if (archivosTexto.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada",jornada.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Invoca al metodo Leer de la clase Texto. 
        /// </summary>
        /// <returns>Retorna un string con lo leido, un string vacio si no logra leer.</returns>
        public static string Leer()
        {
            string auxiliar = "";
            IArchivo<string> archivosTexto = new Texto();
            if (archivosTexto.Leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada",out auxiliar))
            {
                return auxiliar;
            }
            return auxiliar;
        }

        /// <summary>
        /// Muestra los datos de una jornada, Inocada al metodo ToString de la clase Profesor y Alumno.
        /// <returns>Retorna un string con los datos de una jornada.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("CLASE DE: {0} POR {1}ALUMNOS: \r\n", this.clases.ToString(), this.instructor.ToString());
            foreach (Alumno alumno in this.alumnos)
            {
                cadena.AppendFormat("{0}\r\n", alumno.ToString());
            }
            return cadena.ToString();
        }

        #endregion
    }
}
