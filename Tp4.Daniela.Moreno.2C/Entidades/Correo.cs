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
            string s = "";
            if (elementos is List<Paquete>)
            {
                //string s = string.Format ("{0} {1}",elementos.MostrarDatos,elementos.Es)
                s = string.Format("{0}", elementos.ToString());
            }
            return s;
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
            if (!(c is null) && !(p is null))
            {
                foreach (Paquete paq in c.paquetes)
                {
                    if (paq!=p)
                    {
                        c.paquetes.Add(p);
                        Thread hilo = new Thread(p.MockCicloDeVida);//aca llamo al metodo
                        
                        c.mockPaquetes.Add(hilo);
                        hilo.Start();
                        return c;
                    }else
                    {
                        throw new TrakingIdRepetidoException();
                    }
                }
            }
            return c;//dejar mas lindo
        }
    }
}
