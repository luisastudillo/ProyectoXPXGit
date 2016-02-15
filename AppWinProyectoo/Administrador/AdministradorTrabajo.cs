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

        public AdministradorTrabajo(AdministradorMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            borrarCasillas();
            activarCasillas();
            chbBaja.Enabled = false;
            txtCodigo.Text = LogicaNegocios.LogicaTrabajo.siguienteCodigo().ToString();
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

        private void btnBaja_Click(object sender, EventArgs e)
        {
            LogicaNegocios.LogicaTrabajo.bajar(Convert.ToInt32(txtCodigo.Text));
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

                string descripcion;
                decimal costo;
                int codigo;
                bool baja;
                codigo = Convert.ToInt32(txtCodigo.Text);
                costo = Convert.ToDecimal(txtCosto.Text);
                baja = chbBaja.Checked;
                descripcion = txtDescripcion.Text;
                if (editando)
                {
                    editar(codigo, descripcion, costo, baja);
                }
                else
                {
                    nuevo(codigo, descripcion, costo, baja);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }
        }

        private void nuevo(int codigo, string descripcion, decimal costo, bool baja)
        {
            string agregado = LogicaNegocios.LogicaTrabajo.nuevo(codigo,descripcion,costo, baja);
            if (agregado == "exito")
            {
                MessageBox.Show("Trabajo creado");
                inicializar();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el trabajo \n" + agregado);
            }
        }

        private void editar(int codigo, string descripcion, decimal costo, bool baja)
        {
            
            string resultado = LogicaNegocios.LogicaTrabajo.editar(codigo, descripcion, costo, baja);
            if (resultado == "exito")
            {
                MessageBox.Show("Trabajo editado con éxito");
                inicializar();
                
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
                    if (txtCodigo.Text == "")
                    {
                        MessageBox.Show("Ingrese un código");
                        return;
                    }
                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    Entidades.Trabajo encontrado = LogicaNegocios.LogicaTrabajo.buscar(codigo);
                    if (encontrado != null)
                    {
                        mostrarTrabajo(encontrado);
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

        private void mostrarTrabajo(Entidades.Trabajo t)
        {
            txtCodigo.Text = t.Codigo.ToString();
            txtCosto.Text = t.Costo.ToString();
            txtDescripcion.Text = t.Descripcion;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Administrador.AdministradorTrabajosListar ventana = new Administrador.AdministradorTrabajosListar(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void inicializar()
        {
            borrarCasillas();
            desactivarCasillas();
            activarBotones();
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnBaja.Enabled = false;
        }

        private void AdministradorTrabajo_Load(object sender, EventArgs e)
        {
            inicializar();
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
