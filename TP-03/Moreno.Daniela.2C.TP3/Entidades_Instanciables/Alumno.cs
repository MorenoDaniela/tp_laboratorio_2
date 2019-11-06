using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades_Instanciables.Universidad;

namespace Entidades_Instanciables
{
#pragma warning disable CS0661,CS0660
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        public Alumno()
            : base()
        {

        }

        public Alumno(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad, EClases claseQueToma)
            : base (id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            string auxiliar = "";
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    auxiliar = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    auxiliar = "Becado";
                    break;
                case EEstadoCuenta.Deudor:
                    auxiliar = "Deudor";
                    break;
            }
            cadena.AppendFormat("{0}\r\nESTADO DE CUENTA {1}\r\n{2}", base.MostrarDatos(), auxiliar, this.ParticiparEnClase());
            return cadena.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("\r\nTOMA CLASES DE: {0}", this.claseQueToma.ToString());
            return cadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (!(a is null) && a.claseQueToma==clase && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (!(a is null) && a.claseQueToma!=clase)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
