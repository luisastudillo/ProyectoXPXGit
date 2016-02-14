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
    public partial class AdministradorTrabajosListar : Form
    {
        AdministradorTrabajo anterior;

        public AdministradorTrabajosListar()
        {
            InitializeComponent();
        }

        public AdministradorTrabajosListar(AdministradorTrabajo anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void AdministradorTrabajosListar_Load(object sender, EventArgs e)
        {
            llenarTabla(LogicaNegocios.LogicaTrabajo.lista());
        }

        public void llenarTabla(List<Entidades.Trabajo> listaTrabajos)
        {
            DataGridViewRow row;
            dgvTrabajos.Rows.Clear();
            dgvTrabajos.AllowUserToAddRows = true;
            foreach (Entidades.Trabajo t in listaTrabajos)
            {
                row = (DataGridViewRow)dgvTrabajos.Rows[0].Clone();
                row.Cells[0].Value = t.Codigo;
                row.Cells[1].Value = t.Descripcion;
                row.Cells[2].Value = t.Costo;                
                dgvTrabajos.Rows.Add(row);
            }
            dgvTrabajos.AllowUserToAddRows = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.anterior.Visible = true;
            this.Close();
        }
    }
}
