using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo
{
    public partial class AdministradorTrabajo : Form
    {
        bool editando = false;
        AdministradorMenu anterior;

        public AdministradorTrabajo()
        {
            InitializeComponent();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            activarCasillas();
            txtCodigo.ReadOnly = true;
            editando = true;
            desactivarBotones();
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            activarBotones();
            desactivarCasillas();
            borrarCasillas();
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnBaja.Enabled = false;
            btnBuscar.Text = "Busqueda";
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Close();
        }
    }
}
