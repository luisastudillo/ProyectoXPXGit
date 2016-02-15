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
    public partial class RecepcionClienteListar : Form
    {
        Form anterior;

        public RecepcionClienteListar()
        {
            InitializeComponent();
        }

        public RecepcionClienteListar(Form anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RecepcionClienteListar_Load(object sender, EventArgs e)
        {
            llenarTabla(LogicaNegocios.LogicaCliente.listaClientes());
        }

        public void llenarTabla(List<Entidades.Cliente> listaClientes)
        {
            DataGridViewRow row;
            dgvClientes.Rows.Clear();
            dgvClientes.AllowUserToAddRows = true;
            foreach (Entidades.Cliente c in listaClientes)
            {
                row = (DataGridViewRow)dgvClientes.Rows[0].Clone();
                row.Cells[0].Value = c.Cedula;
                row.Cells[1].Value = c.Nombre;
                row.Cells[2].Value = c.Apellido;
                row.Cells[3].Value =c.Domicilio;
                row.Cells[4].Value = c.Telefono;
                row.Cells[5].Value = c.Celular;
                dgvClientes.Rows.Add(row);
            }
            dgvClientes.AllowUserToAddRows = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Entidades.Cliente> lista;
            if (rbtApellido.Checked)
                lista = listarPorApellido();
            else if (rbtCedula.Checked)
                lista = listarPorCedula();
            else
                lista = listarPorNombre();
            llenarTabla(lista);
        }
        private List<Entidades.Cliente> listarPorNombre()
        {
            string dato = txtBuscar.Text;
            List<Entidades.Cliente> listaClientes = LogicaNegocios.LogicaCliente.listaClientes();
            List<Entidades.Cliente> listaRetorno = new List<Entidades.Cliente>();
            foreach (Entidades.Cliente c in listaClientes)
            {
                if (c.Nombre.ToLower().Contains(dato.ToLower()))
                {
                    listaRetorno.Add(c);
                }
            }
            return listaRetorno;
        }

        private List<Entidades.Cliente> listarPorCedula()
        {
            string dato = txtBuscar.Text;
            List<Entidades.Cliente> listaClientes = LogicaNegocios.LogicaCliente.listaClientes();
            List<Entidades.Cliente> listaRetorno = new List<Entidades.Cliente>();

            foreach (Entidades.Cliente c in listaClientes)
            {
                if (c.Cedula.Contains(dato))
                {
                    listaRetorno.Add(c);
                }
            }
            return listaRetorno;
        }

        private List<Entidades.Cliente> listarPorApellido()
        {
            string dato = txtBuscar.Text;
            List<Entidades.Cliente> listaClientes = LogicaNegocios.LogicaCliente.listaClientes();
            List<Entidades.Cliente> listaRetorno = new List<Entidades.Cliente>();

            foreach (Entidades.Cliente c in listaClientes)
            {
                if (c.Apellido.ToLower().Contains(dato.ToLower()))
                {
                    listaRetorno.Add(c);
                }
            }
            return listaRetorno;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            llenarTabla(LogicaNegocios.LogicaCliente.listaClientes());
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
