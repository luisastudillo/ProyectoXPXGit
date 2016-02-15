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
    public partial class TecnicoEntregar : Form
    {
        TecnicoMenu anterior;

        public TecnicoEntregar()
        {
            InitializeComponent();
        }

        public TecnicoEntregar(TecnicoMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void TecnicoEntregar_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }
        private void llenarCombo()
        {
            List<Entidades.Ingreso> ingresados = LogicaNegocios.LogicaIngreso.listaAceptados();
            foreach (Entidades.Ingreso i in ingresados)
                cmbCodigos.Items.Add(i.Codigo);
        }

        private void cmbCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = (int)cmbCodigos.SelectedItem;
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            Entidades.Equipo equipo = LogicaNegocios.LogicaIngreso.equipo(codigo);
            txtEquipo.Text = equipo.Tipo;
            txtModelo.Text = equipo.Modelo;
            txtSerie.Text = equipo.Serie;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresar();
        }
        private void regresar()
        {
            anterior.Visible = true;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbCodigos.Text == "")
            {
                MessageBox.Show("Seleccione un equipo");
                return;
            }
            int codigo = (int)cmbCodigos.SelectedItem;
            bool resultado = LogicaNegocios.LogicaIngreso.entregar(codigo);
            if (resultado)
            {
                MessageBox.Show("Equipo entregado");
                regresar();
            }
            else
                MessageBox.Show("Error entregando equipo");

        }
    }
}
