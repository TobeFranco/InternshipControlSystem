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
    public partial class StudentDetails_Revisor : Form
    {
        private int IDstudent;
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
        public StudentDetails_Revisor(Student student)
        {
           
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Proyect proyect = ProyectsDAO.GetItem(student);
            Tutor tutor = TutorDAO.GetItem(student.Tutor_id);
            Company company = CompanyDao.GetItem(student.company_idDao);
            Company_Assessor assessor = Company_AssessorsDAO.GetItem(company.Company_Assessor_Id);
            this.IDstudent = student.Id;

            // Fill in fields.
            lblProyectName.Text = proyect.Name;
            lblChosenOption.Text = proyect.ChosenOptionDao;
            lblPeriod.Text = proyect.Period;

            lblCoordinator.Text = student.Cordinator;
            lblCareer.Text = student.Career;
            lblTutor.Text = tutor.FirstName + " " + tutor.LastName;

            lblCompanyName.Text = company.Name;
            lblRFC.Text = company.RFC;
            lblAsesor.Text = assessor.FirstName + " "+assessor.LastName;

            lblStudentName.Text = student.First_name + " " + student.Last_name;
            lblNoControl.Text = student.Control_id;
            lblStudentCareer.Text = student.Career;
            lblSemesterStudent.Text = student.Semester+"";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void chbLiberar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLiberar.Checked == true)
            {
                if (StudentsDAO.GetRev1(IDstudent) == true)
                {
                    StudentsDAO.UpdateRevision2(IDstudent, true);
                }
                else
                {
                    StudentsDAO.UpdateRevision1(IDstudent, true);
                }
            }
            else
            {
                if (StudentsDAO.GetRev2(IDstudent) == true)
                {
                    StudentsDAO.UpdateRevision2(IDstudent, false);
                }
                else
                {
                    StudentsDAO.UpdateRevision1(IDstudent, false);
                }
            }
        }
    }
}
