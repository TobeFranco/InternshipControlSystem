using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InternshipControlSystem.Front_End
{
    public partial class Login : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
 (
     int nLeftRect, // x-coordinate of upper-left corner
     int nTopRect, // y-coordinate of upper-left corner
     int nRightRect, // x-coordinate of lower-right corner
     int nBottomRect, // y-coordinate of lower-right corner
     int nWidthEllipse, // height of ellipse
     int nHeightEllipse // width of ellipse
 );

        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            txtPassword.UseSystemPasswordChar = true;
            ToolTip tool = new ToolTip();
            tool.IsBalloon = true;
            tool.SetToolTip(txtUser, "Ingrese su nombre de usuario");
            tool.SetToolTip(txtPassword, "Ingrese su contraseña");
            tool.SetToolTip(btnIngresar, "Ingresar");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost;user=root;database=internships;port=3306;password=tereteamo12345");
            conectar.Open();
            MySqlCommand comando = new MySqlCommand();
            MySqlConnection con = new MySqlConnection();
            comando.Connection = conectar;
            String contraseña = txtPassword.Text;
            String usuario = txtUser.Text;
            comando.CommandText = ("select * from users where username= '" + usuario.Trim()+ "' and password_key=sha1('" + contraseña.Trim()+"')");
            MySqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                Principal_Assessor obj = new Principal_Assessor();
                obj.Show();
                Login lo = new Login();
                lo.Hide();
                txtPassword.Text = "";
                txtUser.Text = "";
                
            }
            else
            {
                MessageBox.Show("DATOS INCORRECTOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contraseña = null;
                usuario = null;
                txtPassword.Text = "";
                txtUser.Text = "";
            }
        }

    }
    
}
