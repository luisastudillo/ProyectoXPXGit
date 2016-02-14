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
    public partial class AdministradorPiezasListar : Form
    {
        AdministradorPiezas anterior;


        public AdministradorPiezasListar()
        {
            InitializeComponent();
        }

        public AdministradorPiezasListar(AdministradorPiezas anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void AdministradorPiezasListar_Load(object sender, EventArgs e)
        {
            List<Entidades.Pieza> lista = LogicaNegocios.LogicaPieza.lista();
            llenarTabla(lista);
        }

        public void llenarTabla(List<Entidades.Pieza> listaPîezas)
        {
            DataGridViewRow row;
            dgvPiezas.Rows.Clear();
            dgvPiezas.AllowUserToAddRows = true;
            foreach (Entidades.Pieza p in listaPîezas)
            {
                row = (DataGridViewRow)dgvPiezas.Rows[0].Clone();
                row.Cells[0].Value = p.Codigo;
                row.Cells[1].Value = p.Modelo;
                row.Cells[2].Value = p.Tipo;
                row.Cells[3].Value = p.Costo;
                row.Cells[4].Value = p.Cantidad;
                row.Cells[5].Value = p.Baja;
                dgvPiezas.Rows.Add(row);
            }
            dgvPiezas.AllowUserToAddRows = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Entidades.Pieza> lista = LogicaNegocios.LogicaPieza.lista();
            llenarTabla(lista);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.anterior.Visible = true;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text == "")
            {
                MessageBox.Show("Ingrese texto a buscar");
                return;
            }
            List<Entidades.Pieza> lista;
            if (rbtModelo.Checked)
                lista = LogicaNegocios.LogicaPieza.listaPorModelo(txtBuscar.Text);
            else
                lista = LogicaNegocios.LogicaPieza.listaPorTipo(txtBuscar.Text);
            llenarTabla(lista);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.anterior.Visible = true;
            this.Close();
        }
    }
}
