﻿using System;
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
    public partial class TecnicoAceptar : Form
    {
        TecnicoMenu anterior;

        public TecnicoAceptar()
        {
            InitializeComponent();
            LogicaNegocios.LogicaTrabajoRealizado.eliminar(1, 1);
        }

        public TecnicoAceptar(TecnicoMenu anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TecnicoAceptar_Load(object sender, EventArgs e)
        {
            llenarCombo();
            //cmbCodigos.SelectedIndex = 0;
        }

        private void llenarCombo()
        {
            List<Entidades.Ingreso> ingresados = LogicaNegocios.LogicaIngreso.listaIngresados();
            foreach (Entidades.Ingreso i in ingresados)
                cmbCodigos.Items.Add(i.Codigo);
        }

        private void llenar()
        {
            int codigo = (int)cmbCodigos.SelectedItem;
            Entidades.Ingreso ingreso = LogicaNegocios.LogicaIngreso.buscar(codigo);
            Entidades.Equipo equipo = LogicaNegocios.LogicaIngreso.equipo(codigo);
            txtEquipo.Text = equipo.Tipo;
            txtModelo.Text = equipo.Modelo;
            txtSerie.Text = equipo.Serie;
            txtProblema.Text = ingreso.Problema;
            txtObservacion.Text = ingreso.Observaciones;            
        }

        private void cmbCodigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(cmbCodigos.Text == "")
            {
                MessageBox.Show("Seleccione un equipo");
                return;
            }
            int codigo = (int)cmbCodigos.SelectedItem;
            bool resultado = LogicaNegocios.LogicaIngreso.aceptar(codigo);
            if (resultado)
            {
                MessageBox.Show("Equipo aceptado");
                regresar();
            }else
                MessageBox.Show("Error aceptando equipo");
        }

        private void regresar()
        {
            anterior.Visible = true;
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresar();
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
