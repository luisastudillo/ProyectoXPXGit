using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo.Administrador
{
    public partial class AdministradorProducto : Form
    {
        bool editando = false;
        AdministradorMenu anterior;

        public AdministradorProducto()
        {
            InitializeComponent();
        }

        public AdministradorProducto(AdministradorMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AdministradorProductoListar ventana = new AdministradorProductoListar(this);
            this.Visible = false;
            ventana.Visible = true;
        }

        private void btnGrande_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            borrarCasillas();
            activarCasillas();
            chbBaja.Enabled = false;
            txtCodigo.Text = LogicaNegocios.LogicaPieza.siguienteCodigo().ToString();
            txtCodigo.ReadOnly = true;
            desactivarBotones();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        
        public void activarCasillas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).ReadOnly = false;
            }
            chbBaja.Enabled = true;
        }

        public void desactivarCasillas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).ReadOnly = true;
            }
            chbBaja.Enabled = false;
        }

        public void borrarCasillas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
            }
            chbBaja.Checked = false;
        }

        public void desactivarBotones()
        {
            foreach (Control control in this.panel1.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = false;
            }
        }

        public void activarBotones()
        {
            foreach (Control control in this.panel1.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = true;
            }
        }

        private void inicial()
        {
            borrarCasillas();
            desactivarCasillas();
            activarBotones();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBaja.Enabled = false;
            btnEditar.Enabled = false;
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




    }
}
