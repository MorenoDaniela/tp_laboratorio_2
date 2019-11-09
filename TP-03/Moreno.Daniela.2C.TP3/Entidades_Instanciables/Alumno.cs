using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
#pragma warning disable CS0661,CS0660
    /// <summary>
    /// Clase sellada Alumno, no puede heredar.
    /// </summary>
    public sealed class Alumno : Universitario
    {
        #region "Atributos"
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region "Enumerados"
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Crea un alumno invocando al constructor de la clase padre.
        /// </summary>
        public Alumno()
            : base()
        {

        }

        /// <summary>
        /// Crea un alumno reutilizando al constructor de la clase padre.
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">NOMBRE DEL ALUMNO</param>
        /// <param name="apellido">APELLIDO DEL ALUMNO</param>
        /// <param name="dni">DNI DEL ALUMNO</param>
        /// <param name="nacionalidad">NACIONALIDAD DEL ALUMNO</param>
        /// <param name="claseQueToma">CLASE QUE TOMA EL ALUMNO</param>
        public Alumno(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad, EClases claseQueToma)
            : base (id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Crea un alumno reutilizando al constructor de esta misma clase.
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">NOMBRE DEL ALUMNO</param>
        /// <param name="apellido">APELLIDO DEL ALUMNO</param>
        /// <param name="dni">DNI DEL ALUMNO</param>
        /// <param name="nacionalidad">NACIONALIDAD DEL ALUMNO</param>
        /// <param name="claseQueToma">CLASE QUE TOMA EL ALUMNO</param>
        /// <param name="estadoCuenta">ESTADO DE CUENTA DEL ALUMNO</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region  "Metodos"
        /// <summary>
        /// Sobrescribe al metodo MostrarDatos de la clase padre, retorna un string con los datos del alumno. Invoca al metodo ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Implementacion del metodo abstracto ParticiparEnClase de la clase padre. Retorna un string con las clases que toma este alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("TOMA CLASES DE: {0}", this.claseQueToma);
            return cadena.ToString();
        }

        /// <summary>
        /// Sobreescritura de ToString, invoca al metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Operadores"
        /// <summary>
        /// Compara un alumno con una clase, si este toma la clase y no es deudor retorna true, de lo contrario false.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (!(a is null) && !(a!=clase) && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Compara un alumno con una clase, si este no toma la clase retorna true, de lo contrario false.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (!(a is null) && a.claseQueToma!=clase)
            {
                retorno = true;
            }
            return retorno;
        }

        #endregion
    }
}
