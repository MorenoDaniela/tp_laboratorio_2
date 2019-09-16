using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Boton operar, Invoca al metodo Operar y muestra su resultado en una etiqueta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double numero;
            numero = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = numero.ToString();
        }
        /// <summary>
        /// Realiza una operacion matematica, invoca al metodo Operar de la clase Numero.
        /// </summary>
        /// <param name="numero1">Numero1 formato string</param>
        /// <param name="numero2">Numero2 formato string</param>
        /// <param name="operador">Operando string</param>
        /// <returns>Retorna el resultado de la operacion en caso de ser posible.</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero uno = new Numero(numero1);
            Numero dos = new Numero(numero2);
            double resultado;
            resultado = Calculadora.Operar(uno, dos, operador);
            return resultado;
            //lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Boton limpiar, innvoca al metodo limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpia las etiquetas en donde se encuentran los numeros, el resultado y el operador.
        /// </summary>
        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }
        /// <summary>
        /// Cierra el formulario Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Convierte el resultado decimal en un numero binario de ser posible, Invoca al metodo DecimalBinario de la clase Numero. Muestra el resultado en pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero(lblResultado.Text);
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Convierte un numero binario en decimal de ser posible, Invoca al metodo DecimalBinario de la clase Numero, muestra por pantalla el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero(lblResultado.Text);
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
        }
    }
}
