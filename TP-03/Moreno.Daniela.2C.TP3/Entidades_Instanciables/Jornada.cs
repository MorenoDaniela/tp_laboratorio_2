using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using Archivos;
using Excepciones;
using static Entidades_Instanciables.Universidad;

namespace Entidades_Instanciables
{
#pragma warning disable CS0660,CS0661
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clases;
        private Profesor instructor;

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clases = clase;
            this.instructor = instructor;
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

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno alum in j.alumnos)
            {
                if (alum == a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null) && !(a is null))
            {
                if (j!=a)
                {
                    j.alumnos.Add(a);
                }
            }
            return j;
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            IArchivo<string> archivosTexto = new Texto();
            if (archivosTexto.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada Guardada",jornada.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }

        public static string Leer()
        {
            string auxiliar = "";
            IArchivo<string> archivosTexto = new Texto();
            if (archivosTexto.Leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada Guardada",out auxiliar))
            {
                return auxiliar;
            }
            return auxiliar;
        }

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
    }
}
