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
        bool facturaIngresada = false;
        bool clienteIngresado = false;
        bool equipoIngresado = false;


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
            desactivarBotonesPartes();

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
                    btnEditar.Enabled = true;
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
            activarBotonesPartes();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            activarCasillas();
            txtCodigo.ReadOnly = true;
            editando = false;
            txtCodigo.Text = LogicaNegocios.LogicaRecepcionEquiposIngreso.siguienteIngreso().ToString();
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
            btnEditar.Enabled = false;
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
            txtNomCliente.Text = "";
            txtCodigo.Text = "";
            txtNFactura.Text = "";
            txtNVeces.Text = "";
            txtObservacion.Text = "";
            txtProblema.Text = "";
            txtSerie.Text = "";
            txtNVeces.Text = "";
            txtEquipo.Text = "";
            txtModelo.Text = "";
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
            txtNomCliente.ReadOnly = true;
            txtCodigo.ReadOnly = true;
            txtNFactura.ReadOnly = true;
            txtNVeces.ReadOnly = true;
            txtObservacion.ReadOnly = true;
            txtProblema.ReadOnly = true;
            txtSerie.ReadOnly = true;
            txtEquipo.ReadOnly = true;
            txtModelo.ReadOnly = true;
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
            agregarFactura(numero);
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            dtpFechaFactura.Enabled = false;
            txtCedFactura.ReadOnly = true;
            btnAgregarFactura.Text = "Agregar";
            borrarFactura();
        }
                
        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            string serie = txtSerie.Text;
            if(btnAgregarEquipo.Text == "Agregar")
            {
                Entidades.Equipo encontrado = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscarEquipo(serie);
                if (encontrado != null)
                {
                    txtSerie.Text = encontrado.Serie;
                    txtModelo.Text = encontrado.Modelo;
                    txtNVeces.Text = encontrado.N_ingresos.ToString();
                    txtEquipo.Text = encontrado.Tipo;
                    agregarFactura(encontrado.N_factura);
                }
                else
                {
                    btnAgregarEquipo.Text = "Guardar";
                    activarEquipo();
                    borrarEquipo();
                    txtSerie.Text = serie;
                }
            }
            else
            {
                string modelo = txtModelo.Text;
                string equipo = txtEquipo.Text;
                int factura = Convert.ToInt32(txtNFactura.Text);
                short ingresos = 1;

                bool agregado = LogicaNegocios.LogicaRecepcionEquiposIngreso.nuevoEquipo(serie, modelo, equipo, ingresos, factura);
                if (agregado)
                {
                    desactivarEquipo();
                    MessageBox.Show("Se agregó el equipo");
                    btnAgregarEquipo.Text = "Agregar";
                    btnAgregarEquipo.Enabled = false;
                }else
                    MessageBox.Show("No se agregó el equipo");
            }
        }

        private void btAgregarCliente_Click(object sender, EventArgs e)
        {
            string cedula = txtCedCliente.Text;
            Entidades.Cliente cliente = LogicaNegocios.LogicaCliente.buscarCliente(cedula);
            if(cliente != null)
            {
                txtNomCliente.Text = cliente.Nombre + "" + cliente.Apellido;
            }
        }


        private void desactivarBotonesPartes()
        {
            btnCancelarFactura.Enabled = false;
            btnAgregarFactura.Enabled = false;
            btnCancelarCliente.Enabled = false;
            btAgregarCliente.Enabled = false;
            btnCancelarEquipo.Enabled = false;
            btnAgregarEquipo.Enabled = false;
        }

        private void activarBotonesPartes()
        {
            btnCancelarFactura.Enabled = true;
            btnAgregarFactura.Enabled = true;
            btnCancelarCliente.Enabled = true;
            btAgregarCliente.Enabled = true;
            btnCancelarEquipo.Enabled = true;
            btnAgregarEquipo.Enabled = true;
        }

        private void agregarFactura(int numero)
        {
            if (btnAgregarFactura.Text.Equals("Agregar"))
            {

                Entidades.FacturaCompra factura = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscarFactura(numero);
                if (factura != null)
                {
                    txtNFactura.Text = factura.Numero.ToString();
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
                if (agredado)
                {
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

        private void borrarFactura()
        {
            txtNFactura.Text = "";
            dtpFechaFactura.ResetText();
            txtCedFactura.Text = "";
        }

        private void activarEquipo()
        {
            txtModelo.ReadOnly = false;
            txtEquipo.ReadOnly = false;
            txtSerie.ReadOnly = false;
            btnAgregarEquipo.Enabled = true;
        }

        private void desactivarEquipo()
        {
            txtModelo.ReadOnly = true;
            txtEquipo.ReadOnly = true;
            txtSerie.ReadOnly = true;
        }

        private void borrarEquipo()
        {
            txtSerie.Text = "";
            txtEquipo.Text = "";
            txtModelo.Text = "";
            txtNVeces.Text = "1";

        }

        private void btnCancelarEquipo_Click(object sender, EventArgs e)
        {
            activarEquipo();
            borrarEquipo();
        }
    }
}
