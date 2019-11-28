using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    #pragma warning disable CS0660, CS0661
    
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trakingID;
        public delegate void DelegadoEstado(object sender, EventArgs estado);
        public event DelegadoEstado InformaEstado;
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrakingID
        {
            get
            {
                return this.trakingID;
            }
            set
            {
                this.trakingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trakingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trakingID = trakingID;
            this.estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                if (this.Estado == EEstado.Ingresado)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else if (this.Estado == EEstado.EnViaje)
                {
                    this.Estado = EEstado.Entregado;
                }
                this.InformaEstado.Invoke(this.estado, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.InsertarPaquete(this);
            }catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }
           
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            /*
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}\n", p.trakingID, p.direccionEntrega);
            */
            string retorno = "{0} para {1}";
            if (elemento is Paquete)
            {
                Paquete paq = (Paquete)elemento;
                
                string format = string.Format(retorno, paq.trakingID, paq.direccionEntrega);
                retorno = format;
            }
            return retorno;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (!(p1 is null) && !(p2 is null))
            {
                if (p1.TrakingID == p2.TrakingID)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }


    }
}
