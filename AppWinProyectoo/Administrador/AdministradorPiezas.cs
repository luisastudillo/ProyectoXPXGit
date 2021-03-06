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

        private void btnListar_Click(object sender, EventArgs e)
        {
            AdministradorPiezasListar ventana = new AdministradorPiezasListar(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            LogicaNegocios.LogicaProducto.bajar(Convert.ToInt32(txtCodigo.Text));
            MessageBox.Show("Pieza dada de baja");
            inicial();
        }

        private void AdministradorPiezas_Load(object sender, EventArgs e)
        {
            inicial();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (enBlanco())
                {
                    MessageBox.Show("No se puede dejar casillas en blanco");
                    return;
                }

                string modelo, tipo;
                double costo;
                int codigo, cantidad;
                bool baja;
                codigo = Convert.ToInt32(txtCodigo.Text);
                modelo = txtModelo.Text;
                tipo = txtTipo.Text;
                cantidad = Convert.ToInt32(txtCantidad.Text);
                costo = Convert.ToDouble(txtCosto.Text);
                baja = chbBaja.Checked;
                if (editando)
                {
                    editar(codigo, modelo, tipo, costo, cantidad, baja);
                }
                else
                {
                    nuevo(codigo, modelo, tipo, costo, cantidad);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }            
        }

        private void nuevo(int codigo, string modelo, string tipo, double costo, int cantidad)
        {
            string agregado = LogicaNegocios.LogicaPieza.nuevo(codigo,modelo,tipo,costo,cantidad);
            if (agregado == "exito")
            {
                MessageBox.Show("Pieza creada");
                borrarCasillas();
                desactivarCasillas();
                activarBotones();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se pudo agregar la pieza \n" + agregado);
            }
        }

        private void editar(int codigo, string modelo, string tipo, double costo, int cantidad, bool baja)
        {
            string resultado = LogicaNegocios.LogicaPieza.editar(codigo, modelo, tipo, costo, cantidad, baja);
            if (resultado == "exito")
            {
                MessageBox.Show("Pieza editada con éxito");
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
            if (btnBuscar.Text == "Buscar")
            {

               
                    if (txtCodigo.Text == "")
                    {
                        MessageBox.Show("Ingrese un código");
                        return;
                    }

                try
                {
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    Entidades.Pieza encontrado = LogicaNegocios.LogicaPieza.buscar(codigo);
                    if (encontrado != null)
                    {
                        mostrarPieza(encontrado);
                        btnBuscar.Text = "Busqueda";
                        activarBotones();
                        desactivarCasillas();
                        btnCancelar.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnBaja.Enabled = true;
                    }
                    else
                        MessageBox.Show("Pieza no encontrada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
                }

                
                }
            else
            {
                    borrarCasillas();
                    desactivarCasillas();
                    txtCodigo.ReadOnly = false;
                    txtCodigo.ReadOnly = false;
                    desactivarBotones();
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnBuscar.Text = "Buscar";
                }
            
        }

        private void mostrarPieza(Entidades.Pieza p)
        {
            txtCodigo.Text = p.Codigo.ToString();
            txtModelo.Text = p.Modelo;
            txtTipo.Text = p.Tipo;
            txtCosto.Text = p.Costo.ToString();
            txtCantidad.Text = p.Cantidad.ToString();
            chbBaja.Enabled = true;
            chbBaja.Checked = p.Baja;
            chbBaja.Enabled = false;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
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
