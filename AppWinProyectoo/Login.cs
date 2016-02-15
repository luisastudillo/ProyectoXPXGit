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

        //public void Conexion()
        //{
        //    try
        //    {
        //        cn = new SqlConnection("Data Source=USER;Initial Catalog=BaseXPX;Integrated Security=True");
        //        cn.Open();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
        //    }
        //}

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula, contrasenia;
            cedula = txtcedula.Text;
            contrasenia = txtContrasenia.Text;
            Entidades.Usuario usuario = LogicaNegocios.LogicaLogin.ingresar(cedula, contrasenia);

            if(usuario == null )
                MessageBox.Show("Cedula o contraseña incorrectos");
            else
            {
                Form menu = new Form();
                switch (usuario.Tipo)
                {
                    case "recepcionista  ":
                        MessageBox.Show("Bienvenido al menu de recepcion");
                        menu = new RecepcionMenu(this);
                        break;
                    case "tecnico        ":
                        MessageBox.Show("Bienvenido al menu de Tecnico");
                        menu = new Tecnico.TecnicoMenu();
                        //menu = new  Menu(this)
                        break;
                    case "administrador  ":
                        MessageBox.Show("Bienvenido al menu de administracion");
                        menu = new AdministradorMenu();
                        break;
                }

                menu.Visible = true;
                this.Visible = false;
            }

        }
        
    }
}
