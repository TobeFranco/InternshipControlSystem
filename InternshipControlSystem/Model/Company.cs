using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Company
    {
        // Variables de Clase
        public int Id;
        public String Name;
        public String RFC;
        public int Company_Assessor_Id;

        public String TurnDao;
        public String CompanyHomeDao;
        
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

        // Constructor de la Clase
        public Company(int Id, String Name, String RFC, String Turn, String CompanyHome,String CompanyColoni,
            String CP, String FAX, String PhoneCompany, String CompanyCity, String TitularName, string TitularPosition, String AdvisoryName,
            String AdvisoryPosition, String AgreedName, String Agreed)
        {
            this.Id = Id;
            this.Name = Name;
            this.RFC = RFC;
            
            this.TurnDao = Turn;
            this.CompanyHomeDao = CompanyHome;
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
        }
    }
}
