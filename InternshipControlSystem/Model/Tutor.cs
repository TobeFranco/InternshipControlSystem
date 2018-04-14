using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Tutor
    {
        // Variables de Clase
        public int Id;
        public String FirstName;
        public String LastName;

        // Constructor de la clase
        public Tutor(int Id, String FirstName, String LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
