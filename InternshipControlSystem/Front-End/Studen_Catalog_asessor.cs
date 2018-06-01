using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipControlSystem.Back_End;
using InternshipControlSystem.Model;

namespace InternshipControlSystem.Front_End
{
    public partial class Studen_Catalog_asessor : Form
    {
        private List<Student> students;
        private List<Student> displayStudents;
        private Student selectedStudent;

        
        public Studen_Catalog_asessor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
      
            students = new List<Student>();
            students = StudentsDAO.GetAllItemsInTutor(1);
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
