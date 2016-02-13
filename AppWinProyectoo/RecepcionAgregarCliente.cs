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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Dispose();
        }
    }
}
