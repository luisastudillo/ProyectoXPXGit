﻿using System;
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
        RecepcionMenu anterior;
        bool editando = false;

        public RecepcionCliente()
        {
            InitializeComponent();
        }

        public RecepcionCliente(RecepcionMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
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
            try
            {
                if (enBlanco())
                {
                    MessageBox.Show("No se puede dejar casillas en blanco");
                    return;
                }

                string cedula, nombres, apellidos, direccion, telefono, celular;
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
            try
            {
                

                
                if (btnBuscar.Text == "Buscar")
                {
                    if (txtCedula.Text == "")
                    {
                        MessageBox.Show("No se puede dejar cedula en blanco");
                        return;
                    }
                    string cedula = txtCedula.Text;

                    bool valida = LogicaNegocios.Validador.validarCedula(cedula);
                    if (!valida)
                    {
                        MessageBox.Show("Cédula no válida");
                        return;
                    }

                    Entidades.Cliente encontrado = LogicaNegocios.LogicaCliente.buscar(cedula);
                    if (encontrado != null)
                    {
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
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
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
