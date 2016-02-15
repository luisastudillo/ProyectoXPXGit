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
    public partial class AdministradorRecepcion : Form
    {
        AdministradorMenu anterior;
        bool editando = false;

        public AdministradorRecepcion()
        {
            InitializeComponent();
        }

        public AdministradorRecepcion(AdministradorMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void AdministradorRecepcion_Load(object sender, EventArgs e)
        {
            borrarCasillas();
            desactivarCasillas();
            activarBotones();
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            cmbTipo.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (enBlanco())
                {
                    MessageBox.Show("No se puede dejar casillas en blanco");
                    return;
                }
                string cedula, nombres, apellidos, direccion, telefono, contrasenia, tipo;
                cedula = txtCedula.Text;
                bool valida = LogicaNegocios.Validador.validarCedula(cedula);
                if (!valida)
                {
                    MessageBox.Show("Cédula no válida");
                    return;
                }
                nombres = txtNombre.Text;
                apellidos = txtApellido.Text;
                direccion = txtDireccion.Text;
                telefono = txtTelefono.Text;
                contrasenia = txtContrasenia.Text;
                tipo = (string)cmbTipo.SelectedItem;
                bool baja = chbBaja.Checked;
                if (editando)
                {
                    editar(cedula, nombres, apellidos, direccion, telefono, contrasenia, tipo, baja);
                }
                else
                {
                    nuevo(cedula, nombres, apellidos, direccion, telefono, contrasenia, tipo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }            
        }

        private void nuevo(string cedula, string nombre, string apellido, string domicilio, string telefono, string contrasenia, string tipo)
        {
            bool agregado = LogicaNegocios.LogicaUsuario.nuevo(cedula, nombre, apellido, domicilio, telefono, contrasenia, tipo);
            if (agregado)
            {
                MessageBox.Show("Usuario agregado");
                borrarCasillas();
                desactivarCasillas();
                activarBotones();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente \n");
            }
        }

        private void editar(string cedula, string nombre, string apellido, string domicilio, string telefono, string contrasenia, string tipo, bool baja)
        {
            bool resultado = LogicaNegocios.LogicaUsuario.editar(cedula, nombre, apellido, domicilio, telefono, contrasenia, tipo, baja);
            if (resultado)
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
                MessageBox.Show("Error editando \n");
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
            btnGrande.Enabled = true;
            btnPequenio.Enabled = true;
        }

        public void activarBotones()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            borrarCasillas();
            activarCasillas();
            desactivarBotones();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
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

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnBuscar.Text == "Buscar")
                {
                    if (txtCedula.Text == "")
                    {
                        MessageBox.Show("Ingrese una cedula");
                        return;
                    }
                    string cedula = txtCedula.Text;
                    bool valida = LogicaNegocios.Validador.validarCedula(cedula);
                    if (!valida)
                    {
                        MessageBox.Show("Cédula no válida");
                        return;
                    }
                    Entidades.Usuario encontrado = LogicaNegocios.LogicaUsuario.buscar(cedula);
                    if (encontrado != null)
                    {
                        mostrarUsuario(encontrado);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }
        }

        private void mostrarUsuario(Entidades.Usuario usuario)
        {
            txtCedula.Text = usuario.Cedula;
            txtDireccion.Text = usuario.Domicilio;
            txtContrasenia.Text = usuario.Contrasenia;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtTelefono.Text = usuario.Telefono;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AdministradorUsuarioListar ventana = new AdministradorUsuarioListar(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Entidades.Usuario usuario = LogicaNegocios.LogicaUsuario.buscar(txtCedula.Text);
            usuario.Baja = true;
            bool resutado = LogicaNegocios.LogicaUsuario.editar(usuario);
            if (resutado)
                MessageBox.Show("Usuario dado de baja");
            else
                MessageBox.Show("Error dando de baja al usuario");
        }

        private void btnGrande_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
            }
            foreach (Control control in panel1.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size - 1, control.Font.Style, control.Font.Unit);
            }
            foreach (Control control in panel1.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size - 1, control.Font.Style, control.Font.Unit);
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

    }
}
