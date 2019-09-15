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

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            
            double numero;
            numero = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = numero.ToString();
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero uno = new Numero(numero1);
            Numero dos = new Numero(numero2);
            double resultado;
            resultado = Calculadora.Operar(uno, dos, operador);
            return resultado;
            //lblResultado.Text = resultado.ToString();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero(lblResultado.Text);
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero(lblResultado.Text);
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
        }
    }
}
