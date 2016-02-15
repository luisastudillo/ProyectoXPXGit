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
        
        RecepcionEquipos anterior;

        public RecepcionEquiposIngreso()
        {
            InitializeComponent();
        }

        public RecepcionEquiposIngreso(RecepcionEquipos anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
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
                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("No se puede dejar casillas en blanco");
                    return;
                }

                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
                }

                
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
            if (enBlanco())
            {
                MessageBox.Show("No se puede dejar casillas en blanco");
                return;
            }

            try
            {
                bool resultado;

                int codigo = Convert.ToInt32(txtCodigo.Text);
                DateTime fecha = dtpFecha.Value;
                string problema = txtProblema.Text;
                string observaciones = txtObservacion.Text;
                string accesorios = txtAccesorios.Text;
                string ced_cliente = txtCedCliente.Text;
                string ced_tecnico = "abc";
                string ced_recepcionista = "0702019415";
                string serie_equipo = txtSerie.Text;
                bool garantia = chbGarantia.Checked;
                string estado = "ingresado";
                int n_factura = Convert.ToInt32(txtNFactura.Text);

                if (editando)
                {
                    resultado = LogicaNegocios.LogicaRecepcionEquiposIngreso.editar(codigo, fecha, problema, observaciones, accesorios, ced_cliente, ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);
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
                    resultado = LogicaNegocios.LogicaRecepcionEquiposIngreso.nuevo(codigo, fecha, problema, observaciones, accesorios, ced_cliente, ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
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
            btnImprimir.Enabled = false;
        }

        public void activarBotones()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled = true;
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
            borrarFactura();
        }
                
        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            if (txtSerie.Text == "")
            {
                MessageBox.Show("No se puede dejar la serie en blanco");
                return;
            }
            string serie = txtSerie.Text;
            Entidades.Equipo encontrado = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscarEquipo(serie);
                if (encontrado != null)
                {
                agregarEquipo(encontrado.Serie);
                }
            else
            {
                Recepcion.RecepcionAgregarEquipo ventana = new Recepcion.RecepcionAgregarEquipo(this, serie);
                this.Visible = false;
                ventana.Visible = true;
            }
            
        }

        public void agregarFactura(int nFactura)
        {
            Entidades.FacturaCompra f = LogicaNegocios.LogicaFacturaCompra.buscar(nFactura);
            txtCedFactura.Text = f.Cedula;
            txtNFactura.Text = f.Numero.ToString();
            dtpFechaFactura.Value = f.Fecha;
            txtNFactura.Enabled = false;
        }

        public void agregarEquipo(string serie)
        {
            Entidades.Equipo e = LogicaNegocios.LogicaEquipo.buscar(serie);
            txtEquipo.Text = e.Tipo;
            txtSerie.Text = e.Serie;
            txtModelo.Text = e.Modelo;
            txtNVeces.Text = e.N_ingresos.ToString();
            txtSerie.Enabled = false;
            agregarFactura(e.N_factura);
        }

        private void btAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txtCedCliente.Text == "")
            {
                MessageBox.Show("No se puede dejar la cedula en blanco");
                return;
            }
            string cedula = txtCedCliente.Text;
            Entidades.Cliente cliente = LogicaNegocios.LogicaCliente.buscarCliente(cedula);
            if(cliente != null)
            {
                txtNomCliente.Text = cliente.Nombre + "" + cliente.Apellido;
                txtCedCliente.Enabled = false;
            }
            else
            {
                RecepcionAgregarCliente ventana = new RecepcionAgregarCliente(this, cedula);
                ventana.Visible = true;
                this.Visible = false;
            }
        }

        public void agregarCliente(Entidades.Cliente cliente)
        {
            txtCedCliente.Text = cliente.Cedula;
            txtNomCliente.Text = cliente.nombreCompleto();
        }


        private void desactivarBotonesPartes()
        {
            btnCancelarCliente.Enabled = false;
            btAgregarCliente.Enabled = false;
            btnCancelarEquipo.Enabled = false;
            btnAgregarEquipo.Enabled = false;
        }

        private void activarBotonesPartes()
        {
            btnCancelarCliente.Enabled = true;
            btAgregarCliente.Enabled = true;
            btnCancelarEquipo.Enabled = true;
            btnAgregarEquipo.Enabled = true;
        }

        //private void agregarFactura(int numero)
        //{
        //    if (btnAgregarFactura.Text.Equals("Agregar"))
        //    {

        //        Entidades.FacturaCompra factura = LogicaNegocios.LogicaRecepcionEquiposIngreso.buscarFactura(numero);
        //        if (factura != null)
        //        {
        //            txtNFactura.Text = factura.Numero.ToString();
        //            dtpFechaFactura.Value = factura.Fecha;
        //            txtCedFactura.Text = factura.Cedula;
        //        }
        //        else
        //        {
        //            dtpFechaFactura.Enabled = true;
        //            dtpFechaFactura.Text = "";
        //            txtCedFactura.ReadOnly = false;
        //            txtCedFactura.Text = "";
        //            btnAgregarFactura.Text = "Guardar";
        //            btnCancelarFactura.Enabled = true;
        //        }
        //    }
        //    else
        //    {
        //        DateTime fecha = dtpFechaFactura.Value;
        //        string cedula = txtCedFactura.Text;
        //        bool agredado = LogicaNegocios.LogicaRecepcionEquiposIngreso.nuevaFactura(numero, fecha, cedula);
        //        if (agredado)
        //        {
        //            MessageBox.Show("Se agregó la factura");
        //            txtCedFactura.ReadOnly = true;
        //            dtpFechaFactura.Enabled = false;
        //            btnAgregarFactura.Text = "Agregar";
        //            btnCancelarFactura.Enabled = false;
        //        }
        //        else
        //            MessageBox.Show("No se agregó la factura");
        //    }
        //}

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
            borrarEquipo();
            borrarFactura();
            txtSerie.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Close();
        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            
        }
        private void borrarCliente()
        {
            txtCedCliente.Text = "";
            txtNomCliente.Text = "";
            txtCedCliente.Enabled = true;
        }

        private bool enBlanco()
        {
            bool retorno = false;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    if (((TextBox)control).Text == "")
                        retorno = true;
                if (control is Panel)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (control is TextBox)
                            if (((TextBox)control).Text == "")
                                retorno = true;
                    }
                }                   
            }
            return retorno;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPequenio_Click(object sender, EventArgs e)
        {
            pequenio();
        }

        private void btnGrande_Click(object sender, EventArgs e)
        {
            grande();
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
