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
    public partial class Login : Form
    {

        private DataTable dt;
        private SqlDataAdapter da;
        SqlConnection cn;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            RecepcionMenu nuevo = new RecepcionMenu();
            nuevo.Visible = true;
            //this.Close();
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion();
            String cedula, contraseña;
            bool encontrado = false;
            cedula = txtcedula.Text;
            contraseña = txtContrasenia.Text;

            cmd = new SqlCommand("SELECT * FROM Usuario where usu_cedula =" + cedula+ "", cn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for(int i =0; i< dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                cedula = dr["usu_cedula"].ToString();
                contraseña = dr["usu_contrasenia"].ToString();
                if (txtcedula.Text.Equals(cedula) && txtContrasenia.Text.Equals(contraseña))
                {
                    Form  menu  = new Form();
                    switch (dr["usu_tipo"].ToString())
                    {
                        case "recepcionista":
                            MessageBox.Show("Bienvenido al menu de recepcion");
                            menu = new RecepcionMenu();
                            break;
                        case "tecnico":
                            MessageBox.Show("Aun no soportado");
                            break;
                        case "administrador":
                            MessageBox.Show("Bienvenido al menu de administracion");
                            menu = new AdministradorMenu();
                            break;
                    }

                    menu.Visible = true;
                    this.Visible = false;

                    encontrado = true;
                }
               
            }

            if (!encontrado)
                MessageBox.Show("Cedula o contraseña incorrectos");
           


            cn.Close();

        }
        
    }
}
