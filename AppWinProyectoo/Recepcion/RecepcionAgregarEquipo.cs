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
    public partial class RecepcionAgregarEquipo : Form
    {
        RecepcionEquiposIngreso anterior;

        public RecepcionAgregarEquipo()
        {
            InitializeComponent();
        }

        public RecepcionAgregarEquipo(RecepcionEquiposIngreso anterior, string serie)
        {
            InitializeComponent();
            txtSerie.Text = serie;
            this.anterior = anterior;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            if (enBlanco())
            {
                MessageBox.Show("No se puede dejar casillas en blanco");
                return;
            }
            string equipo, serie, modelo;
            int nfactura;
            equipo = txtEquipo.Text;
            modelo = txtModelo.Text;
            serie = txtSerie.Text;
            nfactura = Convert.ToInt32( txtNFactura.Text);
            LogicaNegocios.LogicaEquipo.nuevo(serie, modelo, equipo, nfactura);
            anterior.agregarEquipo(serie);
            salir();
        }

        public void agregarFactura(int nFactura)
        {
            Entidades.FacturaCompra f = LogicaNegocios.LogicaFacturaCompra.buscar(nFactura);
            txtCedFactura.Text = f.Cedula;
            txtNFactura.Text = f.Numero.ToString();
            dtpFechaFactura.Value = f.Fecha;
            txtNFactura.Enabled = false;
        }

        private void RecepcionAgregarEquipo_Load(object sender, EventArgs e)
        {

        }

        private void salir()
        {
            anterior.Visible = true;
            this.Close();
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

        private void btnCancelarEquipo_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (txtNFactura.Text == "")
            {
                MessageBox.Show("No se puede dejar la cedula en blanco");
                return;
            }
            int numero = Convert.ToInt32(txtNFactura.Text);
            Entidades.FacturaCompra f = LogicaNegocios.LogicaFacturaCompra.buscar(numero);
            if(f!= null)
            {
                agregarFactura(f.Numero);
                txtNFactura.Enabled = false;
            }
            else
            {
                RecepcionAgregarFactura ventana = new RecepcionAgregarFactura();
                ventana.Visible = true;
                this.Visible = false;
            }            
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            txtNFactura.Enabled = true;
            txtNFactura.Text = "";
            txtCedFactura.Text = "";
        }
    }
}
