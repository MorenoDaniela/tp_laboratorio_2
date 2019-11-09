using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    /// <summary>
    /// Clase Universidad
    /// </summary>
#pragma warning disable CS0660,CS0661
    public class Universidad
    {
        #region "Atributos"
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Enumerados"
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Retorna la lista de alumnos de la universidad, o la setea.
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
        /// Retorna la lista de profesores o la setea.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Retorna la lista de jornadas o la setea.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        #endregion

        #region "Indexador"

        /// <summary>
        /// Indexador retorna la jornada en el indice indicado.
        /// </summary>
        /// <param name="i">int indice</param>
        /// <returns></returns>
        public Jornada this [int i]
        {
            get
            {
                
                return jornada[i];

            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor que instancia la lista de alumnos, de jornada y de profesores.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Compara una universidad con un alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si el alumno se encuentra en la lista de alumnos de la universidad, false si no.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            if (!(g is null)&& !(a is null))
            {
                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno==a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Reutiliza el constructor de arriba.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si el alumno no se encuentra en la lista de alumnos de la universidad, false si se encuentra.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Compara una universidad con un profesor.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna true si el profesor se encuentra en la lista de profesor de la universidad, false si no.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            if (!(g is null) && !(i is null))
            {
                foreach (Profesor prof in g.profesores)
                {
                    if (prof == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Reutiliza al operador de arriba.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna true si el profesor NO se encuentra en la lista de profesores de la universidad, false si se encuentra.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Compara una universidad con una clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna el primer profesor en la lista de profesores de esa universidad que pueda dar la clase,
        /// de lo contrario lanza la exception SinProfesorException</returns>
        public static Profesor operator ==(Universidad g,EClases clase)
        {
            Profesor profesor = null;
            if (!(g is null))
            {
                foreach (Profesor profe in g.profesores)
                {
                    if (profe == clase)
                    {
                        profesor = profe;
                        break;
                        
                    }else
                    {
                        throw new SinProfesorException();
                    }
                }
            }
            return profesor;
            
        }

        /// <summary>
        /// Compara una universidad con una clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna el primer profesor que no pueda dar la clase en la lista de profesores de la universidad.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            
            Profesor profesor = null;
            if (!(g is null))
            { 
                foreach (Profesor profe in g.profesores)
                {
                    if (profe != clase)
                    {
                        profesor = profe;
                    }
                }
            }
            return profesor;
        }
        /// <summary>
        /// Agrega un alumno a la lista de alumnos de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna la universidad con el alumno agregado en caso de ser posible.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            Universidad uni=null;
            if (!(u is null) && !(a is null))
            {
                if (u!=a)
                {
                    u.alumnos.Add(a);
                    uni = u;
                }else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return uni;
        }
        /// <summary>
        /// Agrega una nueva jornada a la universidad con un nuevo profesor y añade los alumnos que toman esa clase.
        /// </summary>
        /// <param name="g">universidad recibida</param>
        /// <param name="clase">clase recibida</param>
        /// <returns>Retorna la universidad.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            if (!(g is null))
            {
                Profesor profe = (g == clase);
                Jornada jornada = new Jornada(clase, profe);
                
                foreach (Alumno alumno in g.alumnos)
                {
                    if (alumno==clase)
                    {
                        jornada.Alumnos.Add(alumno);
                    }
                }
                g.jornada.Add(jornada);
                 
            }
            return g;
        }
        /// <summary>
        /// Agrega un profesor a la lista de profesores de la universidad.
        /// </summary>
        /// <param name="u">universidad recibida</param>
        /// <param name="i">profesor recibido</param>
        /// <returns>retorna la universidad.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u is null) && !(i is null))
            {
                if (u!=i)
                {
                    u.profesores.Add(i);
                }
            }
            return u;
        }

        #endregion

        #region "Metodos"
        /// <summary>
        /// Invoca al metodo Guardar de la clase XML, serializa una universidad en un xml.
        /// </summary>
        /// <param name="uni">Universidad que recibe.</param>
        /// <returns>Retorna la universidad.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad", uni);
        }
        /// <summary>
        /// Lee un archivo serializado xml.
        /// </summary>
        /// <returns>Retorna la universidad leida.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad = new Universidad();
            if (xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad", out universidad))
            {
                return universidad;
            }
            return universidad;
            
        }
        /// <summary>
        /// Muestra todos los datos de la universidad.
        /// </summary>
        /// <param name="uni">Universidad recibida.</param>
        /// <returns>Retorna un string con todos los datos de la universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                cadena.AppendFormat("{0}", jornada.ToString());
                cadena.AppendLine("<---------------------------------------------------->");
            }
            return cadena.ToString();
        }
        /// <summary>
        /// Sobrescritura del metodo ToString, invoca al metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

    }
}
