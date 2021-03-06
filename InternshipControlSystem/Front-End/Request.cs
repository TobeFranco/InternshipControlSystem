﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipControlSystem.Back_End;
using System.Runtime.InteropServices;

namespace InternshipControlSystem.Front_End
{
    public partial class Request : Form
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
        public Request()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (txtProjectName.Text == "" || cmbChosenOption.Text == "" || txtProjectedPeriod.Text == "" || txtNumberOfResidents.Text == "" || txtCompanyName.Text == "" || cmbTurn.Text == ""
                          || txtCompanyHome.Text == "" || txtRFC.Text == "" || txtCompanyColony.Text == "" || txtCp.Text == "" || txtFax.Text == "" || txtPhoneCompany.Text == "" || txtCompanyCity.Text == ""
                          || txtTitularName.Text == "" || txtTitularPosition.Text == "" || txtAdvisoryName.Text == "" || txtAdvisoryPosition.Text == "" || txtAgreedName.Text == "" || txtAgreed.Text == "")
            {
                MessageBox.Show("faltan datos DE LA EMPRESA");


            }
            else
            {
                if (txtNameResident.Text == "" || txtNumberControl.Text == "" || txtCareer.Text == "" || cmbSocialSecurity.Text == "" || txtHome.Text == "" || txtNumberInsurance.Text == ""
                    || txtEmail.Text == "" || txtphonehouse.Text == "" || txtCity.Text == "" || txtPhone.Text == ""|| txtApellidos.Text==""||txtSemestre.Text=="")
                {
                    MessageBox.Show("faltan datos DE LA escuela");

                }
                else
                {
                    String cortar;
                    int contadorArroba = 0;
                    for (int i=0;i<txtEmail.Text.Length;i++)
                    {
                        cortar = txtEmail.Text.Substring(i, 1);
                        if (cortar.Equals("@"))
                        {
                            contadorArroba++;
                        }
                        

                    }
                    if (contadorArroba>=2)
                    {
                        MessageBox.Show("el correo es incorrecto,tiene arrobas de mas");

                    }
                    else
                    {
                        if (contadorArroba==0)
                        {
                            MessageBox.Show("el correo necesita una @");
                        }
                        else
                        {
                            // datos  de la empresa
                            String ProjectName = txtProjectName.Text;
                            String ChosenOption = cmbChosenOption.Text;
                            String ProjectedPeriod = txtProjectedPeriod.Text;
                            int NumberOfResidents = Convert.ToInt32(txtNumberOfResidents.Text);
                            String companyName = txtCompanyName.Text;
                            String Turn = cmbTurn.Text;
                            String CompanyHome = txtCompanyHome.Text;
                            String RFC = txtRFC.Text;
                            String CompanyColony = txtCompanyColony.Text;
                            String Cp = txtCp.Text;
                            String Fax = txtCp.Text;
                            String PhoneCompany = txtPhoneCompany.Text;
                            String CompanyCity = txtCompanyCity.Text;
                            String TitularName = txtTitularName.Text;
                            String TitularPosition = txtTitularPosition.Text;
                            String AdvisoryName = txtAdvisoryName.Text;
                            String AdvisoryPosition = txtAdvisoryPosition.Text;
                            String AgreedName = txtAgreedName.Text;
                            String Agreed = txtAgreed.Text;
                            //datos de la escuela
                            String NameResident = txtNameResident.Text;
                            String NumberControl = txtNumberControl.Text;
                            String Career = txtCareer.Text;
                            String SocialSecurity = cmbSocialSecurity.Text;
                            String Home = txtHome.Text;
                            int NumberInsurance = Convert.ToInt32(txtNumberInsurance.Text);
                            String Email = txtEmail.Text;
                            String Phonehouse = txtphonehouse.Text;
                            String City = txtCity.Text;
                            String Phone = txtPhone.Text;

                            Model.Company compan = new Model.Company(0, companyName, RFC, Turn, CompanyHome, CompanyColony,
                               Cp, Fax, PhoneCompany, CompanyCity, TitularName, TitularPosition, AdvisoryName, AdvisoryPosition, AgreedName
                               , Agreed);
                            int lastIDCompany = CompanyDao.CreateItem(compan);
                            // se crea el objeto de estudiante y se llena el constructor
                            Model.Student studen = new Model.Student(0,NumberControl,NameResident,txtApellidos.Text,Career,
                                Convert.ToInt32(txtSemestre.Text),"sss",2,SocialSecurity,Home,Email,City,Phonehouse,NumberInsurance,Phone,lastIDCompany,0,0,false,false,false,false,0);
                            
                            int lastIDstudent = StudentsDAO.CreateItem(studen);
                           
                             // se crea el objeto de empresa
                            
                            Model.Proyect pro = new Model.Proyect(0, ProjectName, lastIDCompany, lastIDstudent, ProjectedPeriod, ChosenOption, NumberOfResidents,0);
                            ProyectsDAO.CreateItem(pro);

                            Model.Delivery del = new Model.Delivery(0, lastIDstudent, "Anteproyecto", false);
                            DeliveryDAO.CreateItem(del);
                            Model.Delivery del2 = new Model.Delivery(0, lastIDstudent, "Kardex", false);
                            DeliveryDAO.CreateItem(del2);
                            Model.Delivery del3 = new Model.Delivery(0, lastIDstudent, "Proyecto Final", false);
                            DeliveryDAO.CreateItem(del3);

                            MessageBox.Show("LA SOLICITUD FUE AGREGADA CORRECTAMENTE");
                        }
                    }
                   

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ADIOS :v", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        Back_End.Validacion obj = new Back_End.Validacion();
        private void txtNameResident_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtProjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtNumberOfResidents_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void cmbTurn_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtCompanyColony_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtCompanyColony_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtCompanyCity_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCp_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtCompanyCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtCp_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtPhoneCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtTitularName_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtAdvisoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtAgreedName_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtTitularPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtAdvisoryPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtAgreed_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtSemestre_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void cmbSocialSecurity_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtNumberInsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtphonehouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphonehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtNumberControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros_letras(e);
        }

        private void txtCareer_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void txtSemestre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            obj.soloNumeros(e);
        }

        private void txtCareer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            obj.soloLetras(e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
