using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo.Tecnico
{
    public partial class TecnicoAgregarPieza : Form
    {
        TecnicoModificar anterior;

        public TecnicoAgregarPieza()
        {
            InitializeComponent();
        }

        public TecnicoAgregarPieza(TecnicoModificar anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void TecnicoAgregarPieza_Load(object sender, EventArgs e)
        {
            dgvTrabajos.Rows.Clear();
            dgvTrabajos.AllowUserToAddRows = true;
            DataGridViewRow fila;
            int i = 0;
            List<Entidades.Pieza> lista = LogicaNegocios.LogicaPieza.lista();
            foreach (Entidades.Pieza s in lista)
            {
                fila = (DataGridViewRow)dgvTrabajos.Rows[0].Clone();
                fila.Cells[0].Value = s.Codigo;
                fila.Cells[1].Value = s.descripcion();
                dgvTrabajos.Rows.Add(fila);
                i = 0;
            }
            dgvTrabajos.AllowUserToAddRows = false;
        }

        private void salir()
        {
            anterior.Visible = true;
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvTrabajos.Rows[dgvTrabajos.CurrentCell.RowIndex];
            int codigo = Convert.ToInt32(row.Cells[0].Value);
            anterior.agregarPieza(codigo);
            salir();
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
