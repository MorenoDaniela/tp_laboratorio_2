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
using Excepciones;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }
        
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtBoxDireccion.Text, mskBoxID.Text);
            paquete.InformaEstado += paquete_InformaEstado;
            try
            {
                correo += paquete;
                ActualizarEstados();
            }
            catch (TrakingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void paquete_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paquete_InformaEstado);
                this.Invoke(d, new object[] { sender, e });

            }else
            {
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            listBoxIngresado.Items.Clear();
            listBoxEnviaje.Items.Clear();
            listBoxEntregado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        listBoxIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        listBoxEnviaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        listBoxEntregado.Items.Add(p);
                        break;
                }
                #region CONIF
                /*
                if (p.Estado == Paquete.EEstado.Ingresado)
                {
                    listBoxIngresado.Items.Add(p);
                }
                else if (p.Estado == Paquete.EEstado.EnViaje)
                {
                    listBoxEnviaje.Items.Add(p);
                }
                else if (p.Estado == Paquete.EEstado.Entregado)
                {
                    listBoxEntregado.Items.Add(p);
                }*/
                #endregion
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion <T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                //if (elemento is Paquete)
                //{
                    rtbMostrar.Clear();
                    rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    rtbMostrar.Text.Guardar("salida.txt");
                //}
            }
        }
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)listBoxEntregado.SelectedItem);
        }
    }
}
