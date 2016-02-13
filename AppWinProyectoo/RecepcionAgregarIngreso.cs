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
    public partial class RecepcionAgregarIngreso : Form
    {
        RecepcionFactura anterior;

        public RecepcionAgregarIngreso()
        {
            InitializeComponent();
        }

        public RecepcionAgregarIngreso(RecepcionFactura anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void RecepcionAgregarIngreso_Load(object sender, EventArgs e)
        {
            dgvEquipos.Rows.Clear();
            dgvEquipos.AllowUserToAddRows = true;
            DataGridViewRow fila;
            int i = 0;
            List<string[]> lista = LogicaNegocios.LogicaIngreso.listaCobrar();
            foreach (string[] s in lista)
            {
                fila = (DataGridViewRow)dgvEquipos.Rows[0].Clone();
                for (int j = 0; j < 4; j++)
                    fila.Cells[j].Value = s.ElementAt<string>(j);
                dgvEquipos.Rows.Add(fila);
                i = 0;
            }
            dgvEquipos.AllowUserToAddRows = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvEquipos.Rows[dgvEquipos.CurrentCell.RowIndex];
            int codigo = Convert.ToInt32(row.Cells[0].Value);
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            anterior.agregarIngreso(ingreso);
            anterior.Visible = true;
            this.Dispose();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Dispose();
        }
    }
}
