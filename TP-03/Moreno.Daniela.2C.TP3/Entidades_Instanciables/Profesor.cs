using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades_Instanciables.Universidad;

namespace Entidades_Instanciables
{
#pragma warning disable CS0660,CS0661
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        public Profesor()
            : base()
        {
            
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            : base (id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
        }

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

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0}{1}\r\n", base.MostrarDatos(), this.ParticiparEnClase());
            return cadena.ToString();
        }

        void _randomClases()
        {
            int value;
            value = random.Next(0, 4);
            Thread.Sleep(300);
            EClases aux = (EClases)value;
            clasesDelDia.Enqueue(aux);            
        }
    }
}
