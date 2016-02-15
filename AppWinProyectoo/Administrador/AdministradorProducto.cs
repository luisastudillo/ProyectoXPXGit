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
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
            }
            foreach (Control control in panel1.Controls)
            {
                control.Font = new Font(control.Font.Name, control.Font.Size + 1, control.Font.Style, control.Font.Unit);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            borrarCasillas();
            activarCasillas();
            chbBaja.Enabled = false;
            txtCodigo.Text = LogicaNegocios.LogicaProducto.siguienteCodigo().ToString();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }


            
        }

        private void AdministradorProducto_Load(object sender, EventArgs e)
        {
            inicial();
        }

        private void mostrarProducto(Entidades.Producto p)
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

        private void valido()
        {
            try
            {
                if (btnBuscar.Text == "Buscar")
                {
                    if (txtCodigo.Text == "")
                    {
                        MessageBox.Show("Ingrese un código");
                        return;
                    }
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    Entidades.Producto encontrado = LogicaNegocios.LogicaProducto.buscar(codigo);
                    if (encontrado != null)
                    {
                        mostrarProducto(encontrado);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }
        }


        private void nuevo(int codigo, string modelo, string tipo, double costo, int cantidad)
        {
            string agregado = LogicaNegocios.LogicaProducto.nuevo(codigo, modelo, tipo, costo, cantidad);
            if (agregado == "exito")
            {
                MessageBox.Show("Producto creado");
                inicial();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto \n" + agregado);
            }
        }

        private void editar(int codigo, string modelo, string tipo, double costo, int cantidad, bool baja)
        {
            string resultado = LogicaNegocios.LogicaProducto.editar(codigo, modelo, tipo, costo, cantidad, baja);
            if (resultado == "exito")
            {
                MessageBox.Show("Producto editado con éxito");
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

        private void btnBaja_Click(object sender, EventArgs e)
        {
            LogicaNegocios.LogicaProducto.bajar(Convert.ToInt32(txtCodigo.Text));
            MessageBox.Show("Producto dado de baja");
            inicial();
        }

        private void btnPequenio_Click(object sender, EventArgs e)
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
    }
}
