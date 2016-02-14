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
    public partial class AdministradorUsuarioListar : Form
    {
        AdministradorRecepcion anterior;

        public AdministradorUsuarioListar()
        {
            InitializeComponent();
        }

        public AdministradorUsuarioListar(AdministradorRecepcion anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void AdministradorUsuarioListar_Load(object sender, EventArgs e)
        {
            List<Entidades.Usuario> lista = LogicaNegocios.LogicaUsuario.listaUsuario();
            llenarTabla(lista);
        }

        public void llenarTabla(List<Entidades.Usuario> listaUsuarios)
        {
            DataGridViewRow row;
            dgvUsuarios.Rows.Clear();
            dgvUsuarios.AllowUserToAddRows = true;
            foreach (Entidades.Usuario c in listaUsuarios)
            {
                row = (DataGridViewRow)dgvUsuarios.Rows[0].Clone();
                row.Cells[0].Value = c.Cedula;
                row.Cells[1].Value = c.Nombre;
                row.Cells[2].Value = c.Apellido;
                row.Cells[3].Value = c.Domicilio;
                row.Cells[4].Value = c.Telefono;
                row.Cells[5].Value = c.Tipo;
                dgvUsuarios.Rows.Add(row);
            }
            dgvUsuarios.AllowUserToAddRows = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Entidades.Usuario> lista;
            if (rbtApellido.Checked)
                lista = LogicaNegocios.LogicaUsuario.listaUsuarioPorApellido(txtBuscar.Text);
            else if (rbtCedula.Checked)
                lista = LogicaNegocios.LogicaUsuario.listaUsuarioPorCedula(txtBuscar.Text);
            else
                lista = LogicaNegocios.LogicaUsuario.listaUsuarioPorNombre(txtBuscar.Text);
            llenarTabla(lista);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Entidades.Usuario> lista = LogicaNegocios.LogicaUsuario.listaUsuario();
            llenarTabla(lista);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            anterior.Visible = true;
            this.Close();
        }
    }
}
