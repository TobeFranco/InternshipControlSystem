﻿using System;
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
    public partial class Principal_Administrator : Form
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
        public Principal_Administrator()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ToolTip tool = new ToolTip();
            tool.SetToolTip(btnSolicitud, "Crea una nueva solicitud");
            tool.SetToolTip(btnCatalogosAlumnos, "Mueestra la lista de los alumnos");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            Request obje = new Request();
            obje.Show();
        }

        private void btnCatalogosAlumnos_Click(object sender, EventArgs e)
        {
            Student_Catalog_Administrator SCA = new Student_Catalog_Administrator();
            SCA.Show();
        }

        private void Principal_Administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
