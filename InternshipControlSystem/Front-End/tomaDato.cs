using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toma_datos_residencia
{
    public partial class tomaDato : Form
    {
        public tomaDato()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CompanyName=="")
            {

            }
        }

        private void tomaDato_Load(object sender, EventArgs e)
        {
            // datos  de la empresa
            String ProjectName = txtProjectName.Text;
            String ChosenOption = cmbChosenOption.Text;
            String ProjectedPeriod = txtProjectedPeriod.Text;
            String NumberOfResidents = txtNumberOfResidents.Text;
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
            String NumberInsurance = txtNumberInsurance.Text;
            String Email = txtEmail.Text;
            String Phonehouse = txtphonehouse.Text;
            String City = txtCity.Text;
            String Phone = txtPhone.Text;








        }
    }
}
