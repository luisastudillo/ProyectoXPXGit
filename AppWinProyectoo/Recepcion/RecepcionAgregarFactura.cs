using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo.Recepcion
{
    public partial class RecepcionAgregarFactura : Form
    {
        Recepcion.RecepcionAgregarEquipo anterior;

        public RecepcionAgregarFactura()
        {
            InitializeComponent();
        }

        public RecepcionAgregarFactura(RecepcionAgregarEquipo anterior, int numero)
        {
            InitializeComponent();
            this.anterior = anterior;
            txtNFactura.Text = numero.ToString();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (enBlanco())
                {
                    MessageBox.Show("No se puede dejar casillas en blanco");
                    return;
                }
                int numero = Convert.ToInt32(txtNFactura.Text);
                DateTime fecha = dtpFechaFactura.Value;
                string cedula = txtCedFactura.Text;
                LogicaNegocios.LogicaFacturaCompra.nuevo(numero, fecha, cedula);
                anterior.agregarFactura(numero);
                salir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }           
        }

        private bool enBlanco()
        {
            bool retorno = false;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    if (((TextBox)control).Text == "")
                        retorno = true;
            }
            return retorno;
        }

        private void salir()
        {
            anterior.Visible = true;
            this.Close();
        }

        private void RecepcionAgregarFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void btnGrande_Click(object sender, EventArgs e)
        {
            grande();
        }

        private void btnPequenio_Click(object sender, EventArgs e)
        {
            pequenio();
        }

        private void grande()
        {
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
                if (control is Panel)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        control2.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
                    }
                }
            }
        }

        private void pequenio()
        {
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size - 1, control.Font.Style, control.Font.Unit);
                if (control is Panel)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        control2.Font = new Font(control.Font.Name, control.Font.Size - 1, control.Font.Style, control.Font.Unit);
                    }
                }
            }
        }
    }
}
