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
    public partial class RecepcionFactura : Form
    {

        private DataTable dt;
        private SqlDataAdapter da;
        SqlConnection cn;
        SqlCommand cmd;
        List<DetalleProducto> listadetalles = new List<DetalleProducto>();
        List<Producto> lista_productos = new List<Producto>();

        public RecepcionFactura()
        {
            InitializeComponent();
            numFactura();
        }

        public void numFactura()
        {
            Conexion();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Factura", cn);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DataRow dr = dt.Rows[dt.Rows.Count -1];
                int nFactura =  (int)dr[0] + 1;
                txtNfactura.Text = nFactura.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion");
            }

            cn.Close();
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

        private void btnProducto_Click(object sender, EventArgs e)
        {
            RecepcionAgregarProducto nuevo = new RecepcionAgregarProducto(this);
            nuevo.Visible = true;
            nuevo.Focus();
        }

        public void agregarProducto(Producto p, int cantidad)
        {
            DetalleProducto d = new DetalleProducto();
            d.Cod_producto = p.Codigo;
            d.Num_factura = Convert.ToInt32(txtNfactura.Text);
            d.Cantidad = cantidad;
            d.Descripcion = p.Tipo + " " + p.Modelo;
            d.Subtotal = d.Cantidad * p.Costo;

            p.Cantidad = p.Cantidad - d.Cantidad;

            listadetalles.Add(d);
            lista_productos.Add(p);

            actualizarFactura();
        }

        public void actualizarFactura()
        {
            DataGridViewRow row;
            
            dgvFactura.Rows.Clear();
            dgvFactura.AllowUserToAddRows = true;
            foreach (DetalleProducto d in listadetalles)
            {
                row = (DataGridViewRow)dgvFactura.Rows[0].Clone();
                row.Cells[0].Value = d.Cod_producto;
                row.Cells[1].Value = d.Descripcion;
                row.Cells[2].Value = d.Cantidad;
                row.Cells[3].Value = d.Subtotal/d.Cantidad;
                row.Cells[4].Value = d.Subtotal;
                dgvFactura.Rows.Add(row);
            }
            dgvFactura.AllowUserToAddRows = false;

            actualizarTotales();

        }

        public void actualizarTotales()
        {
            double subtotal = 0, iva = 0, total = 0;

            foreach(DetalleProducto d in listadetalles)
            {
                subtotal += d.Subtotal;
            }

            iva = subtotal * 0.12;
            total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString();
            txtIva.Text = iva.ToString();
            txtTotal.Text = total.ToString();


        }

        public bool productoEsta(int comparar)
        {

            foreach(Producto p in lista_productos)
            {
                if (p.Codigo == comparar)
                    return true;
            }
           
            return false;
        }


        public void actualizarCantidad(int cantidad, int codigo)
        {
            int codigo_actual;
            DataGridViewRow row;

            for (int i = 0; i < dgvFactura.RowCount - 1; i++)
            {
                row = (DataGridViewRow)dgvFactura.Rows[i];
                codigo_actual = (int)row.Cells[0].Value;
                if(codigo_actual == codigo)
                {
                    row.Cells[2].Value = cantidad;
                    row.Cells[4].Value = (double)row.Cells[3].Value * (int)row.Cells[2].Value;
                    dgvFactura.Update();
                    actualizarTotales();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {

        }

        private void RecepcionFactura_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factura f = new Factura();
            f.Numero = Convert.ToInt32( txtNfactura.Text);
            f.Fecha = dtpFecha.Value;
            f.Ced_recep = "0702019415";
            f.Ced_cliente = txtCedCliente.Text;
            f.Subtotal = Convert.ToDouble( txtSubtotal.Text);
            f.Iva = Convert.ToDouble(txtIva.Text);
            f.Total = Convert.ToDouble(txtTotal.Text);
            guardarFactura(f);
            MessageBox.Show("Se guardó factura");
            guardarDetalles();
        }

        public void guardarDetalles()
        {
          
            foreach (DetalleProducto d in listadetalles)
            {
                guardarDetalle(d);
                actualizarCantidad(buscarProducto(d.Cod_producto));
            }
           
        }

        public Producto buscarProducto(int codigo)
        {
            Producto producto = new Producto();
            foreach(Producto p in lista_productos)
            {
                if (p.Codigo == codigo)
                    producto = p;
            }
            MessageBox.Show("Producto encontrado: " + producto.Modelo);
            return producto;
        }

        public void actualizarCantidad(Producto p)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();

            cmd.CommandText = "Update Producto Set pro_cantidad = @cantidad where pro_codigo = @codigo";

            cmd.Parameters.AddWithValue("cantidad", p.Cantidad);
            cmd.Parameters.AddWithValue("codigo", p.Codigo);

            cmd.ExecuteNonQuery();
           
            cn.Close();
        }

       

        private void guardarDetalle(DetalleProducto detalle)
        {
            //Conexion();
            // try
            //{

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();

            cmd.CommandText = "Insert into Detalle_producto(fac_n_factura,pro_codigo,cantidad,subtotal) values(" +
                 "@nfactura,@pro_codigo,@cantidad,@subtotal)";
            cmd.Parameters.AddWithValue("nfactura", detalle.Num_factura);
            cmd.Parameters.AddWithValue("pro_codigo", detalle.Cod_producto);
            cmd.Parameters.AddWithValue("cantidad", detalle.Cantidad);
            cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);

            cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error en conexion en guardar detalle");
            //}
            cn.Close();
        }

        private void guardarFactura(Factura f)
        {
            //Conexion();
            //try
            //{


            cmd = new SqlCommand();

            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "Insert into Factura(fac_n_factura, fac_fecha, fac_ced_recep, fac_ced_cliente, fac_subtotal, fac_iva, fac_total) values(" +
                "@nfactura,@fecha,@ced_recep,@ced_cliente,@subtotal,@iva,@total)";
            cmd.Parameters.AddWithValue("nfactura", f.Numero);
            cmd.Parameters.AddWithValue("fecha", f.Fecha);
            cmd.Parameters.AddWithValue("ced_recep", f.Ced_recep);
            cmd.Parameters.AddWithValue("ced_cliente", f.Ced_cliente);
            cmd.Parameters.AddWithValue("subtotal", f.Subtotal);
            cmd.Parameters.AddWithValue("iva", f.Iva);
            cmd.Parameters.AddWithValue("total", f.Total);


            cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error en conexion guardando factura");
            //}
            cn.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
