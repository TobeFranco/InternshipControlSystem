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
    public partial class Student_Catalog_Administrator : Form
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

        public Student_Catalog_Administrator()
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
        }

        private void btnStudentDetails_Click(object sender, EventArgs e)
        {
            StudentDetails_Administrator det = new StudentDetails_Administrator(selectedStudent);
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
            StudentDetails_Administrator det = new StudentDetails_Administrator(selectedStudent);
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
            WindowState = FormWindowState.Minimized;
        }

        private void exportStudentsToExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                hoja_trabajo.Cells[1, 1] = "No.";
                hoja_trabajo.Cells[1, 2] = "Empresa";
                hoja_trabajo.Cells[1, 3] = "Proyecto";
                hoja_trabajo.Cells[1, 4] = "Tel-Empresa";
                hoja_trabajo.Cells[1, 5] = "Tel-Alumno";
                hoja_trabajo.Cells[1, 6] = "E-mail";
                hoja_trabajo.UsedRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                int index = 1;
                foreach (Student student in displayStudents) { 
                    Company company = CompanyDao.GetItem(student.company_idDao);
                    Proyect proyect = ProyectsDAO.GetItem(student);
                    hoja_trabajo.Cells[index + 1, 1] = index;
                    hoja_trabajo.Cells[index + 1, 2] = company.Name ;
                    hoja_trabajo.Cells[index + 1, 3] = proyect.Name;
                    hoja_trabajo.Cells[index + 1, 4] = company.PhoneCompanyDao;
                    hoja_trabajo.Cells[index + 1, 5] = student.PhoneDao;
                    hoja_trabajo.Cells[index + 1, 6] = student.EmailDao;
                    index++;
                }
                
                hoja_trabajo.UsedRange.Columns.AutoFit();
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void exportVeredictToExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                hoja_trabajo.Cells[1, 1] = "No.";
                hoja_trabajo.Cells[1, 2] = "Control";
                hoja_trabajo.Cells[1, 3] = "Nombre";
                hoja_trabajo.Cells[1, 4] = "Dictamen General";
                hoja_trabajo.Cells[1, 5] = "Asesor";
                hoja_trabajo.Cells[1, 6] = "Dictamen";
                hoja_trabajo.Cells[1, 7] = "Revisor1";
                hoja_trabajo.Cells[1, 8] = "Dictamen";
                hoja_trabajo.Cells[1, 9] = "Revisor2";
                hoja_trabajo.Cells[1, 10] = "Dictamen";
                hoja_trabajo.Cells[1, 11] = "Proyecto";
                hoja_trabajo.Cells[1, 12] = "Empresa";
                hoja_trabajo.UsedRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                int index = 1;
                foreach (Student student in displayStudents)
                {
                    Tutor tutor = TutorDAO.GetItem(student.Tutor_id);
                    Revisor revisor1 = RevisorsDAO.GetItem(student.Revisor1_id);
                    Revisor revisor2 = RevisorsDAO.GetItem(student.Revisor2_id);
                    hoja_trabajo.Cells[index + 1, 1] = index;
                    hoja_trabajo.Cells[index + 1, 2] = student.Control_id;
                    hoja_trabajo.Cells[index + 1, 3] = student.First_name + " " + student.Last_name;
                    hoja_trabajo.Cells[index + 1, 4] = (student.Titulation_Approval)?"Si":"No";
                    hoja_trabajo.Cells[index + 1, 5] = tutor.FirstName + " " + tutor.LastName;
                    hoja_trabajo.Cells[index + 1, 6] = (student.Tutor_Approval) ? "Si" : "No";
                    hoja_trabajo.Cells[index + 1, 7] = revisor1.FirstName + " " + revisor1.LastName;
                    hoja_trabajo.Cells[index + 1, 8] = (student.Revisor1_Approval) ? "Si" : "No";
                    hoja_trabajo.Cells[index + 1, 9] = revisor2.FirstName + " " + revisor2.LastName;
                    hoja_trabajo.Cells[index + 1, 10] = (student.Revisor2_Approval) ? "Si" : "No";
                    hoja_trabajo.Cells[index + 1, 11] = ProyectsDAO.GetItem(student).Name;
                    hoja_trabajo.Cells[index + 1, 12] = CompanyDao.GetItem(student.company_idDao).Name;
                    index++;
                }

                hoja_trabajo.UsedRange.Columns.AutoFit();
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            exportStudentsToExcel();
        }

        private void btnExportDictamen_Click(object sender, EventArgs e)
        {
            exportVeredictToExcel();
        }
    }
}
