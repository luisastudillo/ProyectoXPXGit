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
    public partial class RecepcionCliente : Form
    {
        RecepcionMenu menu;
        bool editando = false;

        public RecepcionCliente()
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void IngresoCliente_Load(object sender, EventArgs e)
        {
            desactivarCasillas();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrarCasillas();
            activarCasillas();
            desactivarBotones();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            editando = false;
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

            if (editando)
            {
                editar(cedula, nombres, apellidos, direccion, telefono, celular);
            }
            else
            {
                nuevo(cedula, nombres, apellidos, direccion, telefono, celular);                
            }            
        }

        private void nuevo(string cedula, string nombres, string apellidos, string direccion, string telefono, string celular)
        {
            string agregado = LogicaNegocios.LogicaCliente.nuevo(cedula, nombres, apellidos, direccion, telefono, celular);
            if (agregado == "agregado")
            {
                MessageBox.Show("Cliente agregado");
                borrarCasillas();
                desactivarCasillas();
                activarBotones();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente \n" + agregado);
            }
        }
        
        private void editar(string cedula, string nombres, string apellidos, string direccion, string telefono, string celular)
        {
            string resultado = LogicaNegocios.LogicaCliente.editar(cedula, nombres, apellidos, direccion, telefono, celular);
            if (resultado == "exito")
            {
                MessageBox.Show("Cliente editado con éxito");
                borrarCasillas();
                desactivarCasillas();
                activarBotones();
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnGuardar.Enabled = false;
            }
            else
                MessageBox.Show("Error editando \n" + resultado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            if(btnBuscar.Text == "Buscar")
            {
                Entidades.Cliente encontrado = LogicaNegocios.LogicaCliente.buscar(cedula);
                if (encontrado != null) { 
                    mostrarCliente(encontrado);
                    btnBuscar.Text = "Busqueda";
                    activarBotones();
                    btnCancelar.Enabled = false;
                    btnGuardar.Enabled = false;
                }
                else
                    MessageBox.Show("Cliente no encontrado");
            }
            else
            {
                borrarCasillas();
                desactivarCasillas();
                txtCedula.ReadOnly = false;
                desactivarBotones();
                btnBuscar.Enabled = true;
                btnCancelar.Enabled = true;
                btnBuscar.Text = "Buscar";
            }     
        }

        public void mostrarCliente(Entidades.Cliente cliente)
        {
            txtApellido.Text = cliente.Apellido;
            txtCedula.Text = cliente.Cedula;
            txtCelular.Text = cliente.Celular;
            txtDireccion.Text = cliente.Domicilio;
            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Telefono;
        }

        public void activarCasillas()
        {
            foreach(Control control in this.Controls){
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            activarCasillas();
            txtCedula.ReadOnly = true;
            editando = true;
            desactivarBotones();
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void desactivarBotones()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnListar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void activarBotones()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnListar.Enabled = true;
            btnBuscar.Enabled = true;
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

        private void btnListar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
