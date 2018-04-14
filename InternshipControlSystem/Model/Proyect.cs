using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Proyect
    {
        public int Id;
        public String Name;
        public int Compan_Id;
        public int Student_Id;

        public Proyect(int Id, String Name, int Company_Id, int Student_Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Compan_Id = Company_Id;
            this.Student_Id = Student_Id;
        }
    }
}
