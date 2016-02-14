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
    public partial class AdministradorPiezas : Form
    {
        bool editando = false;
        AdministradorMenu anterior;

        public AdministradorPiezas()
        {
            InitializeComponent();
        }

        public AdministradorPiezas(AdministradorMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editando = false;
            borrarCasillas();
            activarCasillas();
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
        }

        public void desactivarCasillas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).ReadOnly = true;
            }
        }

        public void borrarCasillas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
            }
        }

        public void desactivarBotones()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = false;
            }
        }

        public void activarBotones()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

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
            btnBuscar.Text = "Busqueda";
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Close();
        }
    }
}
