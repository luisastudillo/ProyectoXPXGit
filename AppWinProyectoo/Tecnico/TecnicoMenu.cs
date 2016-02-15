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
    public partial class TecnicoMenu : Form
    {
        public TecnicoMenu()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            TecnicoAceptar nuevo = new TecnicoAceptar(this);
            nuevo.Visible = true;
            this.Visible = false;
        }

        private void btrEntregar_Click(object sender, EventArgs e)
        {
            TecnicoEntregar nuevo = new TecnicoEntregar(this);
            nuevo.Visible = true;
            this.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TecnicoModificar nuevo = new TecnicoModificar(this);
            nuevo.Visible = true;
            this.Visible = false;
        }
    }
}
