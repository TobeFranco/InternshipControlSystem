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

        private bool editionMode;
        private Student student;
        private Company company;
        private Tutor tutor;
        private Proyect project;
        private Revisor revisor1;
        private Revisor revisor2;
        private List<Revisor> revisors;
        private List<Tutor> tutors;

        public StudentDetails_Administrator(Student student)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.student = student;
            project = ProyectsDAO.GetItem(student);
            tutor = TutorDAO.GetItem(student.Tutor_id);
            company = CompanyDao.GetItem(student.company_idDao);
            revisor1 = RevisorsDAO.GetItem(student.Revisor1_id);
            revisor2 = RevisorsDAO.GetItem(student.Revisor2_id);
            //Company_Assessor assessor = Company_AssessorsDAO.GetItem(company);

            // Fill in fields.
            txtProyectName.Text = project.Name;
            txtChosenOption.Text = project.ChosenOptionDao;
            txtPeriod.Text = project.Period;

            txtCoordinator.Text = student.Cordinator;
            txtCareer.Text = student.Career;
            txtTutor.Text = tutor.FirstName + " " + tutor.LastName;

            txtCompanyName.Text = company.Name;
            txtRFC.Text = company.RFC;
            txtCompanyAssessor.Text = company.AdvisoryNameDao;
            // Student Data Fields
            txtStudFirstName.Text = student.First_name;
            txtStudLasName.Text = student.Last_name;
            txtControlNo.Text = student.Control_id;
            txtStudentCareer.Text = student.Career;
            txtSemesterStudent.Text = Convert.ToString(student.Semester);
            // revision progress
            ckbRevisor1.Checked = student.Revisor1_Approval;
            ckbRevisor2.Checked = student.Revisor2_Approval;
            ckbTutor.Checked = student.Tutor_Approval;

            // Fill the combos
            revisors =  RevisorsDAO.GetAllItems();
            foreach(Revisor rev in revisors)
            {
                if (rev.Id == revisor1.Id) revisor1 = rev;
                if (rev.Id == revisor2.Id) revisor2 = rev;
                cboRevisor1.Items.Add(rev.FirstName + " " + rev.LastName);
                cboRevisor2.Items.Add(rev.FirstName + " " + rev.LastName);
            }
            tutors = TutorDAO.GetAllItems();
            foreach(Tutor tut in tutors)
            {
                if(tut.Id == tutor.Id) tutor = tut;
                cboTutor.Items.Add(tut.FirstName + " " + tut.LastName);
            }

            cboTutor.SelectedIndex = tutors.IndexOf(tutor);
            cboRevisor1.SelectedIndex = revisors.IndexOf(revisor1);
            cboRevisor2.SelectedIndex = revisors.IndexOf(revisor2);

            // Student Deliveries
            foreach (Delivery deliver in DeliveryDAO.GetAllItemsFromStudent(student))
            {
                if (deliver.Delivery_type == cbkAnteproyecto.Text) cbkAnteproyecto.Checked = deliver.Delivered;
                if (deliver.Delivery_type == cbkKardex.Text) cbkKardex.Checked = deliver.Delivered;
                if (deliver.Delivery_type == cbkFinalProyect.Text) cbkFinalProyect.Checked = deliver.Delivered;
            }

            editionMode = false;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editionMode) // Save
            {
                updateFieldChanges();
                switchOffEditingMode();
            }
            else // Editing Mode
            {
                prepareEditingMode();
            }
            
        }

        private void updateFieldChanges()
        {
            project.Name = txtProyectName.Text;
            project.ChosenOptionDao = txtChosenOption.Text;
            project.Period = txtPeriod.Text;
            student.Cordinator = txtCoordinator.Text;
            // Coordinator Career
            company.Name = txtCompanyName.Text;
            company.RFC = txtRFC.Text;
            company.AdvisoryNameDao = txtCompanyAssessor.Text;
            student.First_name = txtStudFirstName.Text;
            student.Last_name = txtStudLasName.Text;
            student.Control_id = txtControlNo.Text;
            student.Semester = Convert.ToInt32(txtSemesterStudent.Text);
            student.Career = txtCareer.Text;

            // Tutor Update
            tutor = tutors.ElementAt(cboTutor.SelectedIndex);
            student.Tutor_id = tutor.Id;
            txtTutor.Text = tutor.FirstName + " " + tutor.LastName; // Also in view

            // Revisors Update
            revisor1 = revisors.ElementAt(cboRevisor1.SelectedIndex);
            revisor2 = revisors.ElementAt(cboRevisor2.SelectedIndex);
            student.Revisor1_id = revisor1.Id;
            student.Revisor2_id = revisor2.Id;

            // Do the actual updates
            StudentsDAO.UpdateItem(student);
            ProyectsDAO.UpdateItem(project);
            CompanyDao.UpdateItem(company);
        }

        private void switchOffEditingMode()
        {
            // Enable all the textbox fields for editing pourposes
            // Project fields
            txtProyectName.Enabled = false;
            txtChosenOption.Enabled = false;
            txtPeriod.Enabled = false;
            txtCoordinator.Enabled = false;
            txtCareer.Enabled = false;
            //txtTutor.Enabled = false; //Noup
            // Company fields
            txtCompanyName.Enabled = false;
            txtRFC.Enabled = false;
            txtCompanyAssessor.Enabled = false;
            // Student Fields
            txtStudFirstName.Enabled = false;
            txtStudLasName.Enabled = false;
            txtControlNo.Enabled = false;
            txtStudentCareer.Enabled = false;
            txtSemesterStudent.Enabled = false;
            // Change mode
            editionMode = false;
            btnEdit.Text = "Editar";
            gpRevision.Enabled = false;
            gpDeliveries.Enabled = true;
            btnFreeStudent.Enabled = true;
            btnRejectStudent.Enabled = true;
        }

        private void prepareEditingMode()
        {
            // Enable all the textbox fields for editing pourposes
            // Project fields
            txtProyectName.Enabled = true;
            txtChosenOption.Enabled = true;
            txtPeriod.Enabled = true;
            txtCoordinator.Enabled = true;
            txtCareer.Enabled = true;
            //txtTutor.Enabled = true; //Noup
            // Company fields
            txtCompanyName.Enabled = true;
            txtRFC.Enabled = true;
            txtCompanyAssessor.Enabled = true;
            // Student Fields
            txtStudFirstName.Enabled = true;
            txtStudLasName.Enabled = true;
            txtControlNo.Enabled = true;
            txtStudentCareer.Enabled = true;
            txtSemesterStudent.Enabled = true;
            // Change mode
            editionMode = true;
            btnEdit.Text = "Guardar";
            gpRevision.Enabled = true;
            gpDeliveries.Enabled = false;
            btnFreeStudent.Enabled = false;
            btnRejectStudent.Enabled = false;
        }

        private void btnFreeStudent_Click(object sender, EventArgs e)
        {
            student.Titulation_Approval = true;
            StudentsDAO.UpdateItem(student);
        }

        private void btnRejectStudent_Click(object sender, EventArgs e)
        {
            this.Close();
            // Maybe delete the student from the database
        }

        private void btnUpdateDeliveries_Click(object sender, EventArgs e)
        {
            foreach(Delivery deliver in DeliveryDAO.GetAllItemsFromStudent(student))
            {
                if (deliver.Delivery_type == cbkAnteproyecto.Text) deliver.Delivered = cbkAnteproyecto.Checked;
                if (deliver.Delivery_type == cbkKardex.Text) deliver.Delivered = cbkKardex.Checked;
                if (deliver.Delivery_type == cbkFinalProyect.Text) deliver.Delivered = cbkFinalProyect.Checked;
                DeliveryDAO.UpdateItem(deliver);
            }
        }
    }
}
