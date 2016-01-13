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
    public partial class RecepcionEquipos : Form
    {
        RecepcionMenu menu;
        public RecepcionEquipos()
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void Equipos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecepcionEquiposIngreso nuevo = new RecepcionEquiposIngreso();
            nuevo.Visible = true;
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            RecepcionEquiposRetiro nuevo = new RecepcionEquiposRetiro();
            nuevo.Visible = true;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            RecepcionEquiposConsulta nuevo = new RecepcionEquiposConsulta();
            nuevo.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecepcionEquiposListar ventana = new RecepcionEquiposListar();
            ventana.Visible = true;
            this.Close();
        }
    }
}
