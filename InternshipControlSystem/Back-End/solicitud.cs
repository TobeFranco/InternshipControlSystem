using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Back_End

{
 public   class solicitud
    {
        public int IdDao;
        public String ProjectNameDao;
        public String ChosenOptionDao;
        public String ProjectedPeriodDao;
        public int NumberOfResidentsDao;
        public String companyNameDao;
        public String TurnDao;
        public String CompanyHomeDao;
        public String RFCDao;
        public String CompanyColonyDao;
        public String CPDao;
        public String FAXDao;
        public String PhoneCompanyDao;
        public String CompanyCityDao;
        public String TitularNameDao;
        public String TitularPositionDao;
        public String AdvisoryNameDao;
        public String AdvisoryPositionDao;
        public String AgreedNameDao;
        public String AgreedDao;
        //datos de la escuela
        public String NameResidentDao;
        public String NumberControlDao;
        public String CareerDao;
        public String SocialSecurityDao;
        public String HomeDao;
        public int NumberInsuranceDao;
        public String EmailDao;
        public String PhonehouseDao;
        public String CityDao;
        public String PhoneDao;



        public solicitud(int id,String ProjectName, String ChosenOption, String ProjectedPeriod, int intNumberOfResidents, String companyName, String Turn, String CompanyHome, String RFC, String CompanyColoni,
            String CP, String FAX, String PhoneCompany, String CompanyCity, String TitularName, string TitularPosition, String AdvisoryName, String AdvisoryPosition, String AgreedName, String Agreed, String NameResident,
            String NumberControl, String Career, String SocialSecurity, String Home, int NumberInsurance, String Email, String Phonehouse, String City, String Phone)
        {
            this.IdDao = id;
            this.ProjectNameDao = ProjectName;
            this.ChosenOptionDao = ChosenOption;
            this.ProjectedPeriodDao = ProjectedPeriod;
            this.NumberOfResidentsDao = intNumberOfResidents;
            this.companyNameDao = companyName;
            this.TurnDao = Turn;
            this.CompanyHomeDao = CompanyHome;
            this.RFCDao = RFC;
            this.CompanyColonyDao = CompanyColoni;
            this.CPDao = CP;
            this.FAXDao = FAX;
            this.PhoneCompanyDao = PhoneCompany;
            this.CompanyCityDao = CompanyCity;
            this.TitularNameDao = TitularName;
            this.TitularPositionDao = TitularPosition;
            this.AdvisoryNameDao = AdvisoryName;
            this.AdvisoryPositionDao = AdvisoryPosition;
            this.AgreedNameDao = Agreed;
            this.AgreedDao = Agreed;
            this.NameResidentDao = NameResident;
            this.NumberControlDao = NumberControl;
            this.CareerDao = Career;
            this.SocialSecurityDao = SocialSecurity;
            this.HomeDao = Home;
            this.NumberInsuranceDao = NumberInsurance;
            this.EmailDao = Email;
            this.PhonehouseDao = Phonehouse;
            this.CityDao = City;
            this.PhoneDao = Phone;



       


        }
 

       


    }
}
