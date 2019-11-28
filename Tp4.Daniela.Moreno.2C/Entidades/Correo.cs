using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Excepciones;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;


        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            
            Correo correoLocal = (Correo)elementos;
            string datosCompletos = "";
            foreach (Paquete p in correoLocal.Paquetes)
            {
                datosCompletos += string.Format("{0} para {1} ({2}) \n\r", p.TrakingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return datosCompletos;
            
            /*
            string s = "";
            if (elementos is List<Paquete>)
            {
                //string s = string.Format ("{0} {1}",elementos.MostrarDatos,elementos.Es)
                s = string.Format("{0}", elementos.ToString());
            }
            return s;*/
        }

        public void FinEntregas()
        {
            foreach (Thread t in mockPaquetes)
            {
                if (t.IsAlive && !(t is null))
                {
                    t.Abort();
                }
            }
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            bool retorno = false;
            if (!(c is null) && !(p is null))
            {
                foreach (Paquete paq in c.paquetes)
                {
                    if (paq == p)
                    {
                        throw new TrakingIdRepetidoException();
                    }

                }
                if (!retorno)
                {
                    c.Paquetes.Add(p);
                    try
                    {
                        Thread t = new Thread(p.MockCicloDeVida);
                        t.Start();
                        c.mockPaquetes.Add(t);
                    }catch (Exception exception)
                    {
                        throw new Exception(exception.Message,exception);
                    }
                    
                }
            }
            return c;//dejar mas lindo
        }
    }
}
