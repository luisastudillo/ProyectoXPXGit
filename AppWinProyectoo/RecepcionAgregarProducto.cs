using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo
{
    public partial class RecepcionAgregarProducto : Form
    {

        private DataTable dt;
        private SqlDataAdapter da;
        SqlConnection cn;
        SqlCommand cmd;
        RecepcionFactura anterior;

        public RecepcionAgregarProducto()
        {
            InitializeComponent();
        }

        public RecepcionAgregarProducto(RecepcionFactura anterior)
        {
            InitializeComponent();
            this.anterior = anterior;
            Conexion();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Producto", cn);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion");
            }

            cn.Close();
        }

        private void RecepcionAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        public void Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=USER;Initial Catalog=BaseXPX;Integrated Security=True");
                cn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[dgvProductos.CurrentCell.RowIndex];
            p.Codigo = Convert.ToInt32(row.Cells[0].Value);
            p.Tipo = row.Cells[1].Value.ToString();
            p.Modelo = row.Cells[2].Value.ToString();
            p.Costo = Convert.ToDouble(row.Cells[3].Value);
            p.Cantidad = Convert.ToInt32(row.Cells[4].Value);
            if (Convert.ToInt32(txtCantidad.Text) < p.Cantidad)
            {
                if (!anterior.productoEsta(p.Codigo))
                {
                    
                    anterior.agregarProducto(p, Convert.ToInt32(txtCantidad.Text));
                    this.Close();
                }
                else {
                    DialogResult Resultado = MessageBox.Show("El producto ya fue ingresado, desea actualizar la cantidad?", "Confirmar", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        anterior.actualizarCantidad(p.Cantidad, p.Codigo);
                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Cantidad no disponible");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
