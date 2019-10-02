using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (!(c is null) && !(p is null))
            {
                if (c.productos.Count < c.espacioDisponible)
                {
                    foreach (Producto product in c.productos)
                    {
                        if (product == p)//preguntar a fede
                        {
                            return c;
                        }    
                    }
                    c.productos.Add(p);


                }
            }
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            if (!(c is null) && !(p is null))
            {
                foreach (Producto product in c.productos)
                {
                    if (product == p)
                    {
                        c.productos.Remove(p);
                        break;
                    }
                }
            }
            return c;
            /*
            foreach (Producto v in c)
            {
                if (v == p)
                {
                    break;
                }
            }

            return c;*/
        }
        #endregion
        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            /*
            StringBuilder cadena = new StringBuilder();
            foreach (Producto product in productos)
            {
                if (product is Snacks)
                {
                    cadena.AppendLine(((Snacks)product).Mostrar());
                }else if(product is Leche)
                {
                    cadena.AppendLine(((Leche)product).Mostrar());
                }else if (product is Dulce)
                {
                    cadena.AppendLine(((Dulce)product).Mostrar());
                }
                //cadena.AppendLine(product.Mostrar());
            }
            return cadena.ToString();*/
           return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            cadena.AppendLine("");
            
            if (!(c is null))
            {
                foreach (Producto product in c.productos)
                {
                    if (tipo == ETipo.Leche && product is Leche)//revisar estos
                    {
                        cadena.AppendLine(product.Mostrar());
                        //cadena.AppendLine(((Leche)product).Mostrar());
                        //aux = ((Leche)product).Mostrar();
                    }
                    else if (tipo == ETipo.Snacks && product is Snacks)
                    {
                        cadena.AppendLine(((Snacks)product).Mostrar());
                        //aux = ((Snacks)product).Mostrar();
                    }
                    else if (product is Dulce && tipo == ETipo.Dulce)
                    {
                        cadena.AppendLine(((Dulce)product).Mostrar());
                        //aux = ((Dulce)product).Mostrar();
                    }else if (tipo== ETipo.Todos)
                    {
                        cadena.AppendLine(product.Mostrar());
                    }
                    
                    //cadena.AppendLine(aux);
                }
            }
           
            return cadena.ToString();

            /*
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (v is Snacks)
                        cadena.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                            cadena.AppendLine(v.Mostrar()); ;
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                        cadena.AppendLine(v.Mostrar());
                        break;
                    default:
                        cadena.AppendLine(v.Mostrar());
                        break;
                }
            }

           return cadena.ToString();*/
        }
        #endregion

        
        
        
    }
}
