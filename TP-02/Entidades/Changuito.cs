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
        #region "Atributos"
        private List<Producto> productos;
        private int espacioDisponible;
        #endregion

        #region "Enumerados"
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado, crea un objeto Changuito, inicializa la lista.
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Crea un objeto Changuito, reutiliza al constructor de arriba pero en este caso se puede definir cuanto espacio disponible tiene este chango.
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible dentro del chango. </param>
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
        /// <returns>Retorna el chango de compras con el producto agregado a la lista en caso de que lo haya podido agregar.</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (!(c is null) && !(p is null))
            {
                if (c.productos.Count < c.espacioDisponible)
                {
                    foreach (Producto product in c.productos)
                    {
                        if (product == p)
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
        /// <returns>Retorna el objeto changuito con el elemento producto quitado de la lista en caso de ser posible.</returns>
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
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
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
        /// <returns>Retorna una cadena de caracteres con los datos del chango segun el tipo especificado de producto</returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            cadena.AppendLine("");

            #region "Otra forma con if"
            /*
            if (!(c is null))
            {
                foreach (Producto product in c.productos)
                {
                    if (tipo == ETipo.Leche && product is Leche)
                    {
                        cadena.AppendLine(((Leche)product).Mostrar());
                    }
                    else if (tipo == ETipo.Snacks && product is Snacks)
                    {
                        cadena.AppendLine(((Snacks)product).Mostrar());
                    }
                    else if (product is Dulce && tipo == ETipo.Dulce)
                    {
                        cadena.AppendLine(((Dulce)product).Mostrar());
                    }else if (tipo== ETipo.Todos)
                    {
                        cadena.AppendLine(product.Mostrar());
                    }
                }
            }
           
            return cadena.ToString();*/
            #endregion

            if (!(c is null))
            {
                foreach (Producto product in c.productos)
                {
                    switch (tipo)
                    {
                        case ETipo.Snacks:
                            if (product is Snacks)
                            {
                                cadena.AppendLine(product.Mostrar());
                            }  
                            break;
                        case ETipo.Dulce:
                            if (product is Dulce)
                            {
                                cadena.AppendLine(product.Mostrar()); ;
                            }
                            break;
                        case ETipo.Leche:
                            if (product is Leche)
                            {
                                cadena.AppendLine(product.Mostrar());
                            }
                            break;
                        default:
                            cadena.AppendLine(product.Mostrar());
                            break;
                    }
                }
            }
           return cadena.ToString();
        }
        #endregion
     
    }
}
