using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipControlSystem.Model;
using System.Runtime.InteropServices;
using InternshipControlSystem.Back_End;

namespace InternshipControlSystem.Front_End
{
    public partial class StudentDetails_Administrator : Form
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
        public StudentDetails_Administrator(Student student)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Proyect proyect = ProyectsDAO.GetItem(student);
            Tutor tutor = TutorDAO.GetItem(student.Tutor_id);
            Company company = CompanyDao.GetItem(student.company_idDao);
            //Company_Assessor assessor = Company_AssessorsDAO.GetItem(company);

            // Fill in fields.
            txtProyectName.Text = proyect.Name;
            txtChosenOption.Text = proyect.ChosenOptionDao;
            txtPeriod.Text = proyect.Period;

            txtCoordinator.Text = student.Cordinator;
            txtCareer.Text = student.Career;
            txtTutor.Text = tutor.FirstName + " " + tutor.LastName;

            txtCompanyName.Text = company.Name;
            txtRFC.Text = company.RFC;
            txtCompanyAssessor.Text = "";
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
