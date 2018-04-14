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

        // Constructor de la Clase
        public Company(int Id, String Name, String RFC, int Company_Assessor_Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.RFC = RFC;
            this.Company_Assessor_Id = Company_Assessor_Id;
        }
    }
}
