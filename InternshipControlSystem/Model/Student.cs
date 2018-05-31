using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    public class Student
    {
        // Variables de clase
        public int Id;
        public String Control_id;
        public String First_name;
        public String Last_name;
        public String Career;
        public int Semester;
        public String Cordinator;
        public int Tutor_id;
        public String SocialSecurityDao;
        public String HomeDao;
        public int NumberInsuranceDao;
        public String EmailDao;
        public String PhonehouseDao;
        public String CityDao;
        public String PhoneDao;
        public int company_idDao;



        // Constructor de la clase
        public Student(int Id, String Control_id, String First_name, String Last_name, String Career,
                        int Semester, String Cordinator, int tutor, String social,String home, String Email,String city,String PhoneHouse, int numeri,String Phone
            ,int idcompany)
        {
            this.Id = Id;
            this.Control_id = Control_id;
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Career = Career;
            this.Semester = Semester;
            this.Cordinator = Cordinator;
            this.Tutor_id = tutor;
            this.SocialSecurityDao = social;
            this.HomeDao = home;
            this.EmailDao = Email;
            this.CityDao = city;
            this.PhonehouseDao = Phone;
            this.NumberInsuranceDao = numeri;
            this.PhoneDao = Phone;
            this.company_idDao = idcompany;
        }
    }
}
