﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Proyect
    {
        // Variables de Clase
        public int Id;
        public String Name;
        public int Company_Id;
        public int Student_Id;
        public string Period;
        public String ChosenOptionDao;
        public int NumberOfResidentsDao;
        public int companyAssesorId;
        // Constructor de la clase
        public Proyect(int Id, String Name, int Company_Id, int Student_Id, string Period,String Chosen,int Number, int companyAssessorId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Company_Id = Company_Id;
            this.Student_Id = Student_Id;
            this.Period = Period;
            this.ChosenOptionDao = Chosen;
            this.NumberOfResidentsDao = Number;
            this.companyAssesorId = companyAssessorId;
        }
    }
}
