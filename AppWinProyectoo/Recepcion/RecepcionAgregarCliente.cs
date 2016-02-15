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
    public partial class RecepcionAgregarCliente : Form
    {
        Form anterior;
        public RecepcionAgregarCliente()
        {
            InitializeComponent();
        }

        public RecepcionAgregarCliente(Form anterior, string cedula)
        {
            InitializeComponent();
            this.anterior = anterior;
            this.txtCedula.Text = cedula;        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula, nombres, apellidos, direccion, telefono, celular;
                cedula = txtCedula.Text;
                nombres = txtNombre.Text;
                apellidos = txtApellido.Text;
                direccion = txtDireccion.Text;
                telefono = txtTelefono.Text;
                celular = txtCelular.Text;
                string agregado = LogicaNegocios.LogicaCliente.nuevo(cedula, nombres, apellidos, direccion, telefono, celular);
                if (agregado == "agregado")
                {
                    MessageBox.Show("Cliente agregado");
                    if (anterior is RecepcionEquiposIngreso)
                    {
                        ((RecepcionEquiposIngreso)anterior).agregarCliente(LogicaNegocios.LogicaCliente.buscarCliente(cedula));
                    }

                    anterior.Visible = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el cliente \n" + agregado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Dispose();
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
