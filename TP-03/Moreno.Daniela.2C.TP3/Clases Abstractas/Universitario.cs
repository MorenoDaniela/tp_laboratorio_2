using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
#pragma warning disable CS0661, CS0659
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            : base ()
        {

        }

        public Universitario(int legajo,string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            : base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

       
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

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0} \r\nLEGAJO NUMERO:{1} \r\n", base.ToString(),this.legajo.ToString());//mirar si necesito saltos para xml
            return cadena.ToString();
        }

        protected abstract string ParticiparEnClase();


    }
}
