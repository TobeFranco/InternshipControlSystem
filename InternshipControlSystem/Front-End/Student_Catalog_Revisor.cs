using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Student_Catalog_Revisor : Form
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
        public Student_Catalog_Revisor(int IDrevisor)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            students = new List<Student>();
            students = StudentsDAO.GetAllItemsInTutor(IDrevisor);
            displayStudents = new List<Student>(students);
            fillTable();
        }


        private void fillTable()
        {
            dgvStudents.ClearSelection();
            dgvStudents.Rows.Clear();
            foreach (Student stud in displayStudents)
            {
               
            }
            btnStudentDetails.Enabled = false;
        }
        private void Studen_Catalog_asessor_Load(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            if (proyect != null)
            {
                lblProyectNameHolder.Text = proyect.Name;
                lblPeriodHolder.Text = proyect.Period;
            }
        }
    }
}
