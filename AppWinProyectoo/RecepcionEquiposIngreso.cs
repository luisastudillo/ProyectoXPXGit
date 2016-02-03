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
    public partial class RecepcionEquiposIngreso : Form
    {
        bool editando = false;

        public RecepcionEquiposIngreso()
        {
            InitializeComponent();
        }

        private void mo(object sender, MouseEventArgs e)
        {

        }

        private void IngresoEquipos_Load(object sender, EventArgs e)
        {
            desactivarCasillas();
            txtCedFactura.ReadOnly = true;
            dtpFechaFactura.Enabled = false;
            activarBotones();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            desactivarBotones();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            activarCasillas();
            txtCodigo.ReadOnly = true;
            
            editando = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string texto = btnBuscar.Text;
            if (texto.Equals("Buscar"))
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                Entidades.Ingreso encontrado = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscar(codigo);
                if (encontrado != null)
                {
                    txtCodigo.Text = encontrado.Codigo.ToString();
                    txtAccesorios.Text = encontrado.Accesorios;
                    txtCedCliente.Text = encontrado.Ced_cliente;
                    dtpFecha.Value = encontrado.Fecha;
                    chbGarantia.Checked = encontrado.Garantia;
                    txtNFactura.Text = encontrado.N_factura.ToString();
                    txtObservacion.Text = encontrado.Observaciones;
                    txtProblema.Text = encontrado.Problema;
                    txtSerie.Text = encontrado.Serie_equipo;
                    activarBotones();
                    desactivarCasillas();
                    btnBuscar.Text = "Busqueda";
                }
                else
                    MessageBox.Show("No se encontró el ingreso");
            }
            else
            {
                btnBuscar.Text = "Buscar";
                desactivarCasillas();
                txtCodigo.ReadOnly = false;
                desactivarBotones();
                btnBuscar.Enabled = true;
                btnCancelar.Enabled = true;
            }



        }





        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado;

            int codigo = Convert.ToInt32(txtCodigo.Text);
            DateTime fecha = dtpFecha.Value;
            string problema = txtProblema.Text;
            string observaciones = txtObservacion.Text;
            string accesorios = txtAccesorios.Text;
            string ced_cliente = txtCedCliente.Text;
            string ced_tecnico = "0701945178";
            string ced_recepcionista = "0702019415";
            string serie_equipo = txtSerie.Text;
            bool garantia = chbGarantia.Checked;
            string estado = "ingresado";
            int n_factura = Convert.ToInt32(txtNFactura.Text);

            if (editando)
            {
                resultado = LogicaNegocios.LogicaRecepcionEquiposIngreso.editar(codigo, fecha, problema, observaciones,
                    accesorios, ced_cliente, ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);
                if (resultado)
                {
                    MessageBox.Show("El ingreso fue editado exitosamente");
                }
                else
                {
                    MessageBox.Show("El ingreso no se pudo actualizar");
                }
            }
            else {
                resultado = LogicaNegocios.LogicaRecepcionEquiposIngreso.nuevo(codigo, fecha, problema, observaciones,
                    accesorios, ced_cliente, ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);
                if (resultado)
                {
                    MessageBox.Show("El ingreso fue creado exitosamente");
                }
                else
                {
                    MessageBox.Show("El ingreso no se pudo crear");
                }
            }
            if (resultado)
            {
                borrarCasillas();
                activarBotones();
                desactivarCasillas();
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            desactivarBotones();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            activarCasillas();
            editando = false;
        }

        private void desactivarBotones()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = false;
            btnCerrar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        public void activarBotones()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
            btnCerrar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void borrarCasillas()
        {
            txtAccesorios.Text = "";
            txtCedCliente.Text = "";
            txtCodigo.Text = "";
            txtNFactura.Text = "";
            txtNVeces.Text = "";
            txtObservacion.Text = "";
            txtProblema.Text = "";
            txtSerie.Text = "";
            chbGarantia.Checked = false;
            dtpFecha.Text= "";
        }

       private void activarCasillas()
        {
            txtAccesorios.ReadOnly = false;
            txtCedCliente.ReadOnly = false;
            txtCodigo.ReadOnly = false;
            txtNFactura.ReadOnly = false;
            txtNVeces.ReadOnly = false;
            txtObservacion.ReadOnly = false;
            txtProblema.ReadOnly = false;
            txtSerie.ReadOnly = false;
            chbGarantia.Enabled= true;
            dtpFecha.Enabled = true;
        }
        private void desactivarCasillas()
        {
            txtAccesorios.ReadOnly = true;
            txtCedCliente.ReadOnly = true;
            txtCodigo.ReadOnly = true;
            txtNFactura.ReadOnly = true;
            txtNVeces.ReadOnly = true;
            txtObservacion.ReadOnly = true;
            txtProblema.ReadOnly = true;
            txtSerie.ReadOnly = true;
            chbGarantia.Enabled = false;
            dtpFecha.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            borrarCasillas();
            activarBotones();
            desactivarCasillas();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtNFactura.Text);

            if (btnAgregarFactura.Text.Equals("Agregar"))
            {
                
                Entidades.FacturaCompra factura = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscarFactura(numero);
                if(factura != null)
                {
                    dtpFechaFactura.Value = factura.Fecha;
                    txtCedFactura.Text = factura.Cedula;
                }
                else
                {
                    dtpFechaFactura.Enabled = true;
                    dtpFechaFactura.Text = "";
                    txtCedFactura.ReadOnly = false;
                    txtCedFactura.Text = "";
                    btnAgregarFactura.Text = "Guardar";
                    btnCancelarFactura.Enabled = true;
                }
            }
            else
            {
                DateTime fecha = dtpFechaFactura.Value;
                string cedula = txtCedFactura.Text;
                bool agredado = LogicaNegocios.LogicaRecepcionEquiposIngreso.nuevaFactura(numero, fecha, cedula);
                if (agredado) { 
                    MessageBox.Show("Se agregó la factura");
                    txtCedFactura.ReadOnly = true;
                    dtpFechaFactura.Enabled = false;
                    btnAgregarFactura.Text = "Agregar";
                    btnCancelarFactura.Enabled = false;
                }
                else
                    MessageBox.Show("No se agregó la factura");
            }
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            dtpFechaFactura.Enabled = false;
            txtCedFactura.ReadOnly = true;
            btnAgregarFactura.Text = "Agregar";
            btnCancelarFactura.Enabled = false;
        }
    }
}
