using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value)!="")
                {
                    this.apellido = value;
                }  
            }
        }

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

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;//fijarse donde tirar la exception
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(ValidarNombreApellido(value) != "")
                {
                    this.nombre = value;
                }
            }
        }

        
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);     
            }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            : this (nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido, int.Parse(dni), nacionalidad)//corregir
        {
            
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("NOMBRE COMPLETO: {0}, ", this.apellido);
            cadena.AppendFormat("{0} \r\nNACIONALIDAD: {1} \r\n", this.nombre,this.nacionalidad.ToString());
            return cadena.ToString();
        }

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

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            //int retorno = 0;

            if (int.TryParse(dato, out int retorno) && dato.Length<=8 && dato.Length>=1)
            {   
                return ValidarDni(nacionalidad, retorno);    
            }else
            {
                throw new DniInvalidoException();
            }
            //return retorno;
            
        }

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





    }
}
