using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Delivery
    {
        public int Id;
        public int Student_Id;
        public string Delivery_type;
        public bool Delivered;

        public Delivery(int id, int student_id, string delivery_type, bool delivered)
        {
            this.Id = id;
            this.Student_Id = student_id;
            this.Delivery_type = delivery_type;
            this.Delivered = delivered;
        }

    }
}
