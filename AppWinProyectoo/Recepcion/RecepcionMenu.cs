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
    public partial class RecepcionMenu : Form
    {
        Login login;
        public RecepcionMenu(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            RecepcionEquipos nuevo = new RecepcionEquipos(this);
            nuevo.Visible = true;
            this.Visible = false;
        }

        private void MenuRecepcion_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            RecepcionCliente nuevo = new RecepcionCliente();
            nuevo.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecepcionFactura nuevo = new RecepcionFactura();
            nuevo.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login.Visible = true;
            this.Dispose();
        }
    }
}
