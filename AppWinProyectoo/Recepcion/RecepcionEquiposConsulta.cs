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
        public RecepcionEquiposConsulta(RecepcionEquipos equipo)
        {
            InitializeComponent();
            this.equipo = equipo;
        }

        private void ConsultaEquipos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("No se puede dejar codigo en blanco");
                return;
            }
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
                txtEstado.Text = ingreso.Estado;
                txtValor.Text = ingreso.Costo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos \n" + ex.Message);
            }

            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            equipo.Visible = true;
            this.Dispose();
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
