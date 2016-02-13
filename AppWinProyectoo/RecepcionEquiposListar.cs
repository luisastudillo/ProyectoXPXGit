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
    public partial class RecepcionEquiposListar : Form
    {
        public RecepcionEquiposListar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RecepcionEquiposListar_Load(object sender, EventArgs e)
        {
            dgvEquipos.Rows.Clear();
            dgvEquipos.AllowUserToAddRows = true;
            DataGridViewRow fila;
            int i = 0;
            List<string[]> lista = LogicaNegocios.LogicaIngreso.lista();
            foreach(string[] s in lista)
            {
                fila = (DataGridViewRow)dgvEquipos.Rows[0].Clone();
                for(int j = 0; j < 5; j++ )
                    fila.Cells[j].Value = s.ElementAt<string>(j);
                dgvEquipos.Rows.Add(fila);
                i=0;
            }
            dgvEquipos.AllowUserToAddRows = false;
        }


    }
}
