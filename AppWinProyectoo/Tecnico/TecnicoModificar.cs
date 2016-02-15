using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AppWinProyectoo.Tecnico
{
    public partial class TecnicoModificar : Form
    {
        int codigo;
        Entidades.Ingreso ingreso;
        TecnicoMenu anterior;

        private List<Entidades.TrabajoRealizado> trabajos = new List<Entidades.TrabajoRealizado>();
        private List<Entidades.PiezaUsada> piezas = new List<Entidades.PiezaUsada>();
        
        public TecnicoModificar()
        {
            InitializeComponent();         
        }

        public TecnicoModificar(TecnicoMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtProblema_TextChanged(object sender, EventArgs e)
        {

        }

        private void TecnicoModificar_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        private void llenarCombo()
        {
            List<Entidades.Ingreso> ingresados = LogicaNegocios.LogicaIngreso.listaAceptados();
            foreach (Entidades.Ingreso i in ingresados)
                cmbCodigos.Items.Add(i.Codigo);
        }

        private void llenarPiezas()
        {
            DataGridViewRow row;            
            dgvPiezas.Rows.Clear();
            dgvPiezas.AllowUserToAddRows = true;
            foreach (Entidades.PiezaUsada p in LogicaNegocios.LogicaPiezaUsada.piezasUsadasPorIngreso(codigo))
            {
                row = (DataGridViewRow)dgvPiezas.Rows[0].Clone();
                row.Cells[0].Value = p.Codigo_pieza;
                row.Cells[1].Value = LogicaNegocios.LogicaPiezaUsada.descripcion(p);               
                dgvPiezas.Rows.Add(row);
            }
            dgvPiezas.AllowUserToAddRows = false;
        }

        private void llenarTrabajos()
        {
            DataGridViewRow row;
            dgvTrabajos.Rows.Clear();
            dgvTrabajos.AllowUserToAddRows = true;
            foreach (Entidades.TrabajoRealizado t in LogicaNegocios.LogicaTrabajoRealizado.trabajosRealizadosPorIngreso(codigo))
            {
                row = (DataGridViewRow)dgvTrabajos.Rows[0].Clone();
                row.Cells[0].Value = t.Codigo_trabajo;
                row.Cells[1].Value = LogicaNegocios.LogicaTrabajoRealizado.descripcion(t);
                dgvTrabajos.Rows.Add(row);
            }
            dgvTrabajos.AllowUserToAddRows = false;
        }

        private void cmbCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigo = (int)cmbCodigos.SelectedItem;
            ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            mostrarIngreso();
        }

        private void mostrarIngreso()
        {
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            Entidades.Equipo equipo = LogicaNegocios.LogicaIngreso.equipo(codigo);
            txtEquipo.Text = equipo.Tipo;
            txtDiagnostico.Text = ingreso.Diagnostico;
            txtModelo.Text = equipo.Modelo;
            txtProblema.Text = ingreso.Problema;
            txtSerie.Text = equipo.Serie;
            llenarPiezas();
            llenarTrabajos();
        }

        public void agregarTrabajo(int codtrabajo)
        {
            LogicaNegocios.LogicaTrabajoRealizado.nuevo(codtrabajo, codigo);
            ingreso.Costo = LogicaNegocios.LogicaIngreso.calcularCosto(codigo);
            mostrarIngreso();
        }

        public void agregarPieza(int codpieza)
        {
            LogicaNegocios.LogicaPiezaUsada.nuevo(codpieza, codigo);
            ingreso.Costo = LogicaNegocios.LogicaIngreso.calcularCosto(codigo);
            mostrarIngreso();
        }

        private void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            TecnicoAgregarTrabajo ventana = new TecnicoAgregarTrabajo(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvTrabajos.Rows[dgvTrabajos.CurrentCell.RowIndex];
            int codTrabajo = Convert.ToInt32(row.Cells[0].Value);
            LogicaNegocios.LogicaTrabajoRealizado.eliminar(codTrabajo, codigo);
            mostrarIngreso();
        }

        private void btnAgregarPieza_Click(object sender, EventArgs e)
        {
            TecnicoAgregarPieza ventana = new TecnicoAgregarPieza(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ingreso.Diagnostico = txtDiagnostico.Text;
            LogicaNegocios.LogicaIngreso.editar(ingreso);
            MessageBox.Show("Se guardó el diagnóstico");
            regresar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresar();
        }
        private void regresar()
        {
            anterior.Visible = true;
            this.Close();
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
