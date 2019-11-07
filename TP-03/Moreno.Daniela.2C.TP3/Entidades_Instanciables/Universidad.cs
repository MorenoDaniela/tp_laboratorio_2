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

namespace Entidades_Instanciables
{
#pragma warning disable CS0660,CS0661
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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
                        //return profe;
                    }else
                    {
                        throw new SinProfesorException();
                    }
                }
            }
            return profesor;
            
        }

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

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad Guardada", uni);
        }

        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad = new Universidad();
            if (xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad Guardada", out universidad))
            {
                return universidad;
            }
            return universidad;
            
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

    }
}
