using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo.Administrador
{
    public partial class AdministradorProductoListar : Form
    {
        AdministradorProducto anterior;

        public AdministradorProductoListar()
        {
            InitializeComponent();
        }

        public AdministradorProductoListar(AdministradorProducto anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
        }

        private void AdministradorProductoListar_Load(object sender, EventArgs e)
        {
            List<Entidades.Producto> listaProductos = LogicaNegocios.LogicaProducto.lista();
            llenarTabla(listaProductos);
        }



        public void llenarTabla(List<Entidades.Producto> listaProductos)
        {
            DataGridViewRow row;
            dgvProductos.Rows.Clear();
            dgvProductos.AllowUserToAddRows = true;
            foreach (Entidades.Producto p in listaProductos)
            {
                row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = p.Codigo;
                row.Cells[1].Value = p.Modelo;
                row.Cells[2].Value = p.Tipo;
                row.Cells[3].Value = p.Costo;
                row.Cells[4].Value = p.Cantidad;
                row.Cells[5].Value = p.Baja;
                dgvProductos.Rows.Add(row);
            }
            dgvProductos.AllowUserToAddRows = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Entidades.Producto> listaProductos = LogicaNegocios.LogicaProducto.lista();
            llenarTabla(listaProductos);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.anterior.Visible = true;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Ingrese texto a buscar");
                return;
            }
            List<Entidades.Producto> lista;
            if (rbtModelo.Checked)
                lista = LogicaNegocios.LogicaProducto.listaPorModelo(txtBuscar.Text);
            else
                lista = LogicaNegocios.LogicaProducto.listaPorTipo(txtBuscar.Text);
            llenarTabla(lista);
        }
    }
}
