﻿using System;
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
    public partial class RecepcionEquiposRetiro : Form
    {
        RecepcionEquipos equipo;
        public RecepcionEquiposRetiro(RecepcionEquipos equipo)
        {
            InitializeComponent();
            this.equipo = equipo;
        }

        private void RetiroEquipos_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        private void llenarCombo()
        {
            List<Entidades.Ingreso> reparados = LogicaNegocios.LogicaIngreso.listaReparados();
            foreach (Entidades.Ingreso i in reparados)
                cmbCodigos.Items.Add(i.Codigo);
        }

        private void cmbCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
        }

        private void llenar()
        {
            int codigo = (int)cmbCodigos.SelectedItem;
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            txtCedula.Text = ingreso.Ced_cliente;
            txtSerie.Text = ingreso.Serie_equipo;
            txtDiagnostico.Text = ingreso.Diagnostico;
            llenarTrabajos( LogicaNegocios.LogicaIngreso.trabajos(codigo));
            txtCosto.Text = ingreso.Costo.ToString();
            if (ingreso.Garantia)
                txtCosto.Text = "0";
        }

        private void llenarTrabajos(List<string> trabajos)
        {
            foreach (string s in trabajos)
                txtTrabajos.AppendText("\n" + s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = (int)cmbCodigos.SelectedItem;
            LogicaNegocios.LogicaIngreso.retirar(codigo);
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
