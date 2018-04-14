using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Student_Delivery
    {
        // Variables de Clase
        public int Id;
        public int Student_id;
        public String Del_type;
        public bool Delivered;

        // Constructor de la clase
        public Student_Delivery(int Id, int Student_id, String Del_type, bool Delivered)
        {
            this.Id = Id;
            this.Student_id = Student_id;
            this.Del_type = Del_type;
            this.Delivered = Delivered;
        }
    }
}
