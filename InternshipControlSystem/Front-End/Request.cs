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

namespace InternshipControlSystem.Front_End
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
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
                        MessageBox.Show(cortar);

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
                            Back_End.solicitud nueva = new Back_End.solicitud(0, ProjectName, ChosenOption, ProjectedPeriod, NumberOfResidents, companyName, Turn, CompanyHome,
                                RFC, CompanyColony, Cp, Fax, PhoneCompany, CompanyCity, TitularName, TitularPosition, AdvisoryName, AdvisoryPosition, AgreedName, Agreed,
                                NameResident, NumberControl, Career, SocialSecurity, Home, NumberInsurance, Email, Phonehouse, City, Phone);
                            Back_End.DaoSolicitud obj = new Back_End.DaoSolicitud();
                            obj.CreateItem(nueva);
                            // se crea el objeto de estudiante y se llena el constructor
                            Model.Student studen = new Model.Student(0,NumberControl,NameResident,txtApellidos.Text,Career,
                                Convert.ToInt32(txtSemestre.Text),"sss",1,SocialSecurity,Home,Email,City,Phonehouse,NumberInsurance,Phone);
                            
                              StudentsDAO.CreateItem(studen);
                           
                             // se crea el objeto de empresea

                             Model.Company compan = new Model.Company(0,companyName,RFC,1,Turn,CompanyHome,CompanyColony,
                                 Cp,Fax,PhoneCompany,CompanyCity,TitularName,TitularPosition,AdvisoryName,AdvisoryPosition,AgreedName
                                 ,Agreed);
                            CompanyDao.CreateItem(compan);
                            
                            Model.Proyect pro = new Model.Proyect(0, ProjectName, 1, 1, ProjectedPeriod, ChosenOption, NumberOfResidents);
                            ProyectsDAO.CreateItem(pro);





                            for (int i=0;i<9;i++)
                            {

                            }




                            



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

        }
    }
}
