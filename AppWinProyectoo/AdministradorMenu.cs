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
    public partial class AdministradorMenu : Form
    {
        public AdministradorMenu()
        {
            InitializeComponent();
        }

        private void AdministradorMenu_Load(object sender, EventArgs e)
        {

            
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            AdministradorRecepcion ventana = new AdministradorRecepcion(this);
            this.Visible = false;
            ventana.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdministradorPiezas ventana = new AdministradorPiezas(this);
            this.Visible = false;
            ventana.Visible = true;
        }
    }
}
