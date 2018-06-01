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
using InternshipControlSystem.Model;
using InternshipControlSystem.Back_End;

namespace InternshipControlSystem.Front_End
{
    public partial class Student_Catalog : Form
    {
        private List<Student> students;
        private List<Student> displayStudents;
        private Student selectedStudent;

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

        public Student_Catalog()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            students = new List<Student>();
            students = StudentsDAO.GetAllItems();
            displayStudents = new List<Student>(students);

            fillTable();
        }

        private void fillTable()
        {
            dgvStudents.ClearSelection();
            dgvStudents.Rows.Clear();
            foreach (Student stud in displayStudents)
            {
                Tutor tutor = TutorDAO.GetItem(stud.Tutor_id);
                String[] row = { stud.Control_id, stud.First_name + " " + stud.Last_name, stud.Career,
                    tutor.FirstName + " " + tutor.LastName};
                dgvStudents.Rows.Add(row);
            }
            btnStudentDetails.Enabled = false;
        }

        private void btnStudentDetails_Click(object sender, EventArgs e)
        {
            StudentDetails det = new StudentDetails(selectedStudent);
            det.Show();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgvStudents.CurrentRow.Index;
            selectedStudent = students.ElementAt(index);
            // Update overview display
            lblStudentNameHolder.Text = selectedStudent.First_name + selectedStudent.Last_name;
            lblNoControlHolder.Text = selectedStudent.Control_id;
            // Proyect info
            Proyect proyect = ProyectsDAO.GetItem(selectedStudent);
            if(proyect != null)
            {
                lblProyectNameHolder.Text = proyect.Name;
                lblPeriodHolder.Text = proyect.Period;
            }
        }

        private void txtNoControlFilter_TextChanged(object sender, EventArgs e)
        {
            // Filter by No. Control
            
            string filterParam = txtNoControlFilter.Text;
            displayStudents.Clear();
            foreach (Student stud in students)
            {
                if(stud.Control_id.StartsWith(filterParam)){
                    displayStudents.Add(stud);
                }
            }
            fillTable();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentDetails det = new StudentDetails(selectedStudent);
            det.Show();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlStudentOverview_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStudentId_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
