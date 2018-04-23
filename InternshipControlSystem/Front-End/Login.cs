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
    }
}
