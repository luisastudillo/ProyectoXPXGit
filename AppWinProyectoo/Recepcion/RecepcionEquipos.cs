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
        public RecepcionEquipos(RecepcionMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void Equipos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecepcionEquiposIngreso nuevo = new RecepcionEquiposIngreso(this);
            this.Visible = false;
            nuevo.Visible = true;
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            RecepcionEquiposRetiro nuevo = new RecepcionEquiposRetiro(this);
            this.Visible = false;
            nuevo.Visible = true;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            RecepcionEquiposConsulta nuevo = new RecepcionEquiposConsulta(this);
            nuevo.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecepcionEquiposListar ventana = new RecepcionEquiposListar(this);
            ventana.Visible = true;
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Close();
        }
    }
}
