using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Persona.
    /// </summary>
    public abstract class Persona
    {
        #region "Atributos"
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region "Enumerados"
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region  "Propiedades"
        /// <summary>
        /// Retorna el apellido, o lo setea, en el caso del set invoca al metodo ValidarNombreApellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);  
            }
        }
        /// <summary>
        /// Retorna el dni o lo setea, en el caso del set invoca al metodo ValidarDni.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
 
            }
        }
        /// <summary>
        /// Retorna la nacionalidad o la setea.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Retorna el nombre o lo setea. En el caso del set invoca al metodo ValidarNombreApellido.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Setea el dni invocando al metodo ValidarDni que recibe un string.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);     
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Crea un objeto de tipo Persona.
        /// </summary>
        /// <param name="nombre">NOMBRE DE LA PERSONA</param>
        /// <param name="apellido">APELLIDO</param>
        /// <param name="nacionalidad">NACIONALIDAD</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Crea un objeto de tipo persona, reutiliza la constructor de arriba.
        /// </summary>
        /// <param name="nombre">NOMBRE DE LA PERSONA</param>
        /// <param name="apellido">APELLIDO DE LA PERSONA</param>
        /// <param name="dni">DNI DE LA PERSONA</param>
        /// <param name="nacionalidad">NACIONALIDAD DE LA PERSONA</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            : this (nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Crea un onjeto de tipo persona, con el dni string, utiliza a la propiedad StringToDNI.
        /// </summary>
        /// <param name="nombre">NOMBRE DE LA PERSONA</param>
        /// <param name="apellido">APELLIDO DE LA PERSONA</param>
        /// <param name="dni">DNI DE LA PERSONA</param>
        /// <param name="nacionalidad">NACIONALIDAD DE LA PERSONA</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Sobreescritura del metodo ToString.
        /// </summary>
        /// <returns>Retorna un string con todos los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("NOMBRE COMPLETO: {0}, ", this.apellido);
            cadena.AppendFormat("{0} \r\nNACIONALIDAD: {1} \r\n", this.nombre,this.nacionalidad.ToString());
            return cadena.ToString();
        }
        /// <summary>
        /// Valida que el dni ingresado coincida con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Retorna el int dni en caso de que pase la validacion, si no lanza la exception
        /// Nacionalidadinvalidaexception</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            
            if (nacionalidad == ENacionalidad.Argentino && dato >0 && dato <90000000)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <=99999999)
            {
                return dato;
            } else
            {
                throw new NacionalidadInvalidaException();
            }
            
        }
        /// <summary>
        /// Valida que el dni ingresado tenga el formato correcto.
        /// </summary>
        /// <param name="nacionalidad">NACIONALIDAD DE LA PERSONA</param>
        /// <param name="dato">dni de la persona string </param>
        /// <returns>Retorna int dni de la persona en caso de pasar la validacion,
        /// caso contrario lanza la exception DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int retorno) && dato.Length<=8 && dato.Length>=1)
            {   
                return ValidarDni(nacionalidad, retorno);    
            }else
            {
                throw new DniInvalidoException();
            }    
        }

        /// <summary>
        /// Valida el nomre o el apellido.
        /// </summary>
        /// <param name="dato">Nombre o apellido recibido.</param>
        /// <returns>Retorna el nombre/apellido si pasa la validacion, de lo contrario retorna un string vacio.</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            foreach(char letra in dato)
            {
                if (Char.IsLetter(letra) && !(Char.IsWhiteSpace(letra)))
                {
                    retorno = dato;
                }
            }
            return retorno;
        }

        #endregion
    }
}
