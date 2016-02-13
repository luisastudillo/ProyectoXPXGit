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
    public partial class RecepcionEquiposConsulta : Form
    {
        RecepcionEquipos equipo;
        public RecepcionEquiposConsulta()
        {
            InitializeComponent();
            this.equipo = equipo;
        }

        private void ConsultaEquipos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            txtEstado.Text = ingreso.Estado;
            txtValor.Text = ingreso.Costo.ToString();
        }
    }
}
